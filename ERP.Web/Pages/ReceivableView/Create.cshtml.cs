using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Dto;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using NToastNotify;

namespace ERP.Pages.ReceivableView
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

        public IActionResult OnGet()
        {

        ViewData["CPMId"] = new SelectList(_context.Person, "Id", "Name");
        ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");
        ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Name");

        
        ActionButtons = _context.ActionButtons.Where(x => x.StatusId == Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63")).ToList();

            return Page();
        }


        public JsonResult OnGetMills(string millCode)
        {

            Mill mill = _context.Mills
                .Include(x => x.City)
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

        public JsonResult OnGetCPMDetails(string cpmId)
        {
            string directNumber  = string.Empty;

            Person person = _context.Person.FirstOrDefault(x => x.Id == Guid.Parse(cpmId));
            if (person != null)
                directNumber = person.PrimaryPhone;
            else
                _toastNotification.AddWarningToastMessage("No rate defined for selected Fabric.");

            return new JsonResult(directNumber);
        }

        [BindProperty]
        public Receivable Receivable { get; set; }
        //public ReceivableViewModel ReceivableViewModel { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }
        
        //
        public IActionResult OnPostAsync(string submit)
        {
            Receivable.CreatedBy = User.Identity.Name;
            Receivable.CreatedBy = User.Identity.Name;
            Receivable.CreatedDate = DateTime.Now;
            Receivable.ModifiedDate = DateTime.Now;
            _context.Receivables.Add(Receivable);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("The Item has been created successfully");
            return RedirectToPage("./Index");

        }

        public JsonResult OnPostReceivable([FromBody]ReceivableViewModel dto)
        {
            Guid statusId = Guid.Empty;
            string btnTxt = dto.ButtonText;

            if (string.Equals(btnTxt.ToUpper(), "CREATE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Submitted").Id;
            else if (string.Equals(btnTxt.ToUpper(), "DRAFT"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Created").Id;

            Receivable model = new Receivable();
            model = JsonConvert.DeserializeObject<Receivable>(dto.ReceivableJson);
            model.MillId = Guid.Parse(dto.MillJson);


            _context.Receivables.Add(model);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("The Item has been created successfully");
            return new JsonResult("The Item has been created successfully");

        }
    }
}