using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Dto;
using ERP.EntityFramework;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using NToastNotify;

namespace ERP.Pages.ConsignmentView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly ConsginmentERPClient _consginmentERPClient;
        private readonly MillERPClient _millERPClient;
        private readonly FabricERPClient _fabricERPClient;

        [BindProperty]
        public ConsignmentOrder ConsignmentOrder { get; set; }
        public List<ConsignmentOrderItem> ConsignmentOrderItems { get; set; }
        public Mill Mill { get; set; }
        public Person CPMPerson { get; set; }
        public Person MangerPerson { get; set; }
        public Person MechanicalPerson { get; set; }
        public Region Region { get; set; }
        public List<CommandButtons> CommandButtons { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }
        public List<OrderComment> OrderComments { get; set; }
        public bool IsReadOnly = false;
        public bool allowModification = true;

        public EditModel(
            ApplicationDbContext context, 
            IToastNotification toastNotification,
            ConsginmentERPClient consginmentERPClient,
            MillERPClient millERPClient,
            FabricERPClient fabricERPClient)
        {
            _context = context;
            _toastNotification = toastNotification;
            _consginmentERPClient = consginmentERPClient;
            _millERPClient = millERPClient;
            _fabricERPClient = fabricERPClient;
        }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConsignmentOrder = await _context.ConsignmentOrders
                            .Include(c => c.Mill)
                            .Include(c => c.Mill.CPMPerson)
                            .Include(c => c.Mill.MangerPerson)
                            .Include(c => c.Mill.MechanicalPerson)
                            .Include(x => x.Region)
                            .Include(x => x.Status)
                            .FirstOrDefaultAsync(m => m.Id == id);

            ConsignmentOrderItems = _context.ConsignmentOrderItem.Where(m => m.ConsignmentOrderId == ConsignmentOrder.Id).ToList();

            OrderComments = _context.OrderComments
                .Include(x => x.Status)
                                .Where(m => m.ConsignmentOrderId == ConsignmentOrder.Id).ToList();

            Region = ConsignmentOrder.Region;

            if (ConsignmentOrder == null)
            {
                return NotFound();
            }

            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Name");


            ActionButtons = _context.ActionButtons.Where(x => x.StatusId == ConsignmentOrder.StatusId).ToList();

            if (ConsignmentOrder.Status.Name == "Approved" || ConsignmentOrder.Status.Name == "Completed" || ConsignmentOrder.Status.Name == "Close")
            {
                IsReadOnly = true;
                allowModification = false;
                _toastNotification.AddInfoToastMessage("No further modification is allowed. Please contact System Admin.");
            }

            return Page();
        }

        public JsonResult OnPostUpdateConsignmentOrder([FromBody]ConsignmentViewModel dto)
        {
            ConsignmentOrder order = new ConsignmentOrder();
            ConsignmentViewModel model = new ConsignmentViewModel();

            Guid statusId = Guid.Empty;
            string btnTxt = dto.buttonText;

            statusId = getStatusId(btnTxt.ToUpper());
            Status status = _context.Status.Where(x => x.Id == statusId).FirstOrDefault();


            if (btnTxt.ToUpper() == "SHIP")
            {
                order = _context.ConsignmentOrders.FirstOrDefault(x => x.Id == Guid.Parse(dto.ConsignmentOrderId));
                if (order != null)
                {
                    order.StatusId = statusId;
                    _context.ConsignmentOrders.Update(order);
                    _context.SaveChanges();
                }
            }
            else
            {
                model.ConsignmentOrderItems = JsonConvert.DeserializeObject<List<ConsignmentOrderItem>>(dto.ConsignmentOrderJson);

                List<Guid> ConsinmentOrderItemIds = model.ConsignmentOrderItems.Select(x => x.Id).ToList();
                List<ConsignmentOrderItem> ExistingConsinmentOrderItems = _context.ConsignmentOrderItem.Where(x => x.ConsignmentOrderId == model.ConsignmentOrderItems[0].ConsignmentOrderId).ToList();
                List<ConsignmentOrderItem> ConsinmentOrderItemIdsToBeDeleted = ExistingConsinmentOrderItems.Where(x => !ConsinmentOrderItemIds.Contains(x.Id)).ToList();
                _context.ConsignmentOrderItem.RemoveRange(ConsinmentOrderItemIdsToBeDeleted);
                _context.SaveChanges();

                List<ConsignmentOrderItem> ConsinmentOrderItemIdsToBeAdded = model.ConsignmentOrderItems
                                                        .Where(x => x.Id == Guid.Empty || x.Id == null)
                                                        .ToList();

                if (ConsinmentOrderItemIdsToBeAdded.Count > 0)
                {
                    _context.ConsignmentOrderItem.AddRange(ConsinmentOrderItemIdsToBeAdded);
                    _context.SaveChanges();
                }

                string MillCode = _context.Mills.Where(x => x.Id == Guid.Parse(dto.MillJson)).Select(x => x.Code).FirstOrDefault();
                string barCode = string.Format("{0} / {1}", DateTime.Now.ToString("dd-MMM-yyyy"), MillCode);

                order = _context.ConsignmentOrders.FirstOrDefault(x => x.Id == model.ConsignmentOrderItems[0].ConsignmentOrderId);

                if (order != null)
                {
                    order.MillId = Guid.Parse(dto.MillJson);
                    order.RegionId = Guid.Parse(dto.RegionJson);
                    order.StatusId = statusId;
                    order.OrderDate = DateTime.Now;
                    order.CreatedBy = User.Identity.Name;
                    order.OrderComments = dto.OrderComments;
                    order.BarCode = barCode;

                    _context.ConsignmentOrders.Update(order);
                    _context.SaveChanges();
                }

            }

            ActionButtons = _context.ActionButtons.Where(x => x.StatusId == ConsignmentOrder.StatusId).ToList();

            PostOrderComments(statusId, order.Id, dto.OrderComments);

            _toastNotification.AddSuccessToastMessage("Consignment order has been updated successfully");
            return new JsonResult("The consignment order has been created successfully");

        }

        private void PostOrderComments(Guid statusId, Guid id, string orderComments)
        {

            OrderComment orderComment = new OrderComment
            {
                StatusId = statusId,
                ConsignmentOrderId = id,
                Comments = orderComments,
                CommentDate = DateTime.Now

            };


            _context.OrderComments.Add(orderComment);
            _context.SaveChanges();

        }

        private Guid getStatusId(string buttonText)
        {
            Guid statusId = Guid.Empty;

            if (string.Equals(buttonText, "CREATE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Created").Id;
            else if (string.Equals(buttonText, "APPROVE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Approved").Id;
            else if (string.Equals(buttonText, "REJECT"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Rejected").Id;
            else if (string.Equals(buttonText, "on-hold"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Completed").Id;
            else if (string.Equals(buttonText, "SHIP"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Shipped").Id;
            else if (string.Equals(buttonText, "UPDATE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Rejected").Id;
            else if (string.Equals(buttonText, "Meeting"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Rejected").Id;

            return statusId;
        }

        private bool ConsignmentOrderExists(Guid id)
        {
            return _context.ConsignmentOrders.Any(e => e.Id == id);
        }
    }
}
