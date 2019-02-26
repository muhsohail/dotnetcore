using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERP.EntityFramework;
using Models;
using Microsoft.EntityFrameworkCore;
using ERP.Dto;
using Newtonsoft.Json;
using NToastNotify;

namespace ERP.Pages.OrderView
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;

        public CreateModel(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        public JsonResult OnGetMills(string millCode)
        {
            
            Mill mill = _context.Mills
                .Include(x =>x.City)
                .Include(x => x.CPMPerson)
                .Include(x => x.MangerPerson)
                .Include(x => x.MechanicalPerson)
                .Where(x => x.Code == millCode).FirstOrDefault();

            _toastNotification.AddSuccessToastMessage("The mill details have been loaded into section", new NotyOptions()
            {
                Timeout = 20
            });

            return new JsonResult(mill);
        }

        public JsonResult OnPostSample([FromBody]CreateOrderModel dto)
        {
            CreateOrderModel model = new CreateOrderModel();
            model.Orders = JsonConvert.DeserializeObject<List<Order>>(dto.OrderJson);
            foreach (Order order in model.Orders)
                order.MillId = Guid.Parse(dto.MillJson);

            _context.Order.AddRange(model.Orders);
            _context.SaveChangesAsync();

            _toastNotification.AddSuccessToastMessage("Order has been created successfully");

            return new JsonResult("The Order has been created successfully");

        }

        public IActionResult OnGet()
        {
            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Name");

            return Page();
        }

        [BindProperty]
        public CreateOrderModel CreateOrderModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(CreateOrderModel.Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}