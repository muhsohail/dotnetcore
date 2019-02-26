using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Dto;
using ERP.EntityFramework;
using ERP.Services;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using NToastNotify;

namespace ERP.Pages.PaperMillProfileView
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly IMillService _millService;
        private readonly IStatusService _statusService;
        private readonly IPaperMillService _paperMillService;

        [BindProperty]
        public PaperMillProfileViewModel CreateViewModel { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }

        public CreateModel(
            ApplicationDbContext context,
            IToastNotification toastNotification,
            IMillService millService,
            IStatusService statusService,
            IPaperMillService paperMillService
            )
        {
            _context = context;
            _toastNotification = toastNotification;
            _millService = millService;
            _statusService = statusService;
            _paperMillService = paperMillService;
        }

        public IActionResult OnGet()
        {
            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Name");

            ActionButtons = _context.ActionButtons.Where(x => x.StatusId == Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63")).ToList();

            return Page();
        }

        public JsonResult OnGetMills(string millCode)
        {
            Mill mill = new Mill();
            if (string.IsNullOrWhiteSpace(millCode))
                _toastNotification.AddWarningToastMessage("Please select mill code first.");
            else
            {
                mill = _millService.GetMillDetails(millCode);

                if (mill.Id != Guid.Empty)
                    _toastNotification.AddWarningToastMessage("The mill details have been loaded into section.");
                else
                    _toastNotification.AddWarningToastMessage("No mill details found.");
            }

            return new JsonResult(mill);
        }


        public JsonResult OnGetProductRate(string fabricId)
        {
            Double askingRate = 0;

            if (!string.IsNullOrWhiteSpace(fabricId) && !string.Equals(fabricId, "undefined"))
            {
                ProductRate rate = _context.ProductRate.FirstOrDefault(x => x.FabricId == Guid.Parse(fabricId));
                if (rate != null)
                    askingRate = rate.AskingRate;
                else
                    _toastNotification.AddWarningToastMessage("No rate defined for selected Fabric.");


            }
            else
                _toastNotification.AddInfoToastMessage("Fabric rate is not found. Please select Fabric.");

            return new JsonResult(askingRate);
        }

        public JsonResult OnPostMillProfileDetails([FromBody]PaperMillProfileViewModel dto)
        {
            Guid statusId = Guid.Empty;
            statusId = _statusService.GetStatusId(dto.buttonText);
            int result = 0;
            string message = string.Empty;

            Guid paperMillProfileId = _paperMillService.AddMillProfile(statusId, dto.MillJson, dto.RegionJson, User.Identity.Name);

            if (paperMillProfileId != Guid.Empty)
                result = _paperMillService.AddMillProfileDetails(paperMillProfileId, dto.PaperMillProfileJson);

            if (result > 0)
                message = "Paper mill profile has been created successfully";
            else
                message = "Something went wrong";

            return new JsonResult(message);
        }
    }
}