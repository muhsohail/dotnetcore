using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Dto;
using ERP.EntityFramework;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Newtonsoft.Json;
using NToastNotify;

namespace ERP.Pages.ConsignmentView
{
    [Authorize(Roles = "Admin, Editor")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly ConsginmentERPClient _consginmentERPClient;
        private readonly MillERPClient _millERPClient;
        private readonly FabricERPClient _fabricERPClient;

        [BindProperty]
        public ConsignmentViewModel ConsignmentViewModel { get; set; }
        public List<CommandButtons> CommandButtons { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }

        public CreateModel(
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

        public async Task<JsonResult> OnGetMills(string millCode)
        {
            Mill mill = await _millERPClient.GetMillByCode(millCode);
            if (mill != null)
                _toastNotification.AddSuccessToastMessage("Mill data reterieved");
            else
                _toastNotification.AddWarningToastMessage("Mill data not found");

            return new JsonResult(mill);
        }


        public async Task<JsonResult> OnGetFabricDescription(string faricId)
        {
            string fabricDescription = await _fabricERPClient.GetFabricDescription(Guid.Parse(faricId));

            if(!string.IsNullOrWhiteSpace(fabricDescription))
                _toastNotification.AddSuccessToastMessage("Fabric description reterieved");
            else
                _toastNotification.AddWarningToastMessage("Fabric descrioptio not found");

            return new JsonResult(fabricDescription);
        }

        public IActionResult OnGet()
        {
            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Name");

            ActionButtons = _context.ActionButtons.Where(x => x.StatusId == Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63")).ToList();

            return Page();
        }

        public async Task<JsonResult> OnPostSample([FromBody]ConsignmentViewModel dto)
        {
            int result = 0;
            Guid statusId = Guid.Empty;
            string btnTxt = dto.buttonText;

            if (string.Equals(btnTxt.ToUpper(), "CREATE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Submitted").Id;
            else if (string.Equals(btnTxt.ToUpper(), "DRAFT"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Created").Id;           
            
            string MillCode = _context.Mills.Where(x => x.Id == Guid.Parse(dto.MillJson)).Select(x => x.Code).FirstOrDefault();
            string barCode = string.Format("{0} / {1}", DateTime.Now.ToString("dd-MMM-yyyy"), MillCode);

            ConsignmentOrder consignmentOrder = new ConsignmentOrder
            {
                MillId = Guid.Parse(dto.MillJson),
                RegionId = Guid.Parse(dto.RegionJson),
                StatusId = statusId,
                OrderDate = DateTime.Now,
                CreatedBy = User.Identity.Name,
                OrderComments = dto.OrderComments,
                BarCode = barCode,
                IsActive = true,
                ConsignmentOrderItems = JsonConvert.DeserializeObject<List<ConsignmentOrderItem>>(dto.ConsignmentOrderJson)
            };

            result = await _consginmentERPClient.CreateConsignmentOrder(consignmentOrder);           

            if(result !=0)
                _toastNotification.AddSuccessToastMessage("Consignment order has been created successfully");
            else
                _toastNotification.AddErrorToastMessage("Error in creating consignment order");

            return new JsonResult("The consignment order has been created successfully");
        }
    }
}