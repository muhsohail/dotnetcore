using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly IPaperMillService _paperMillService;
        private readonly IStatusService _statusService;
        private readonly IActionButtonsService _actionButtonsService;
        private readonly IProductRateService _productRateService;
        [BindProperty]
        public PaperMillProfile PaperMillProfile { get; set; }
        public List<PaperMillProfileDetail> PaperMillProfileDetails { get; set; }
        public Mill Mill { get; set; }
        public Person CPMPerson { get; set; }
        public Person MangerPerson { get; set; }
        public Person MechanicalPerson { get; set; }
        public Region Region { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }

        public EditModel(
            ApplicationDbContext context, 
            IToastNotification toastNotification, 
            IPaperMillService paperMillService,
            IStatusService statusService,
            IActionButtonsService actionButtonsService,
            IProductRateService productRateService
            )
        {
            _context = context;
            _toastNotification = toastNotification;
            _paperMillService = paperMillService;
            _statusService = statusService;
            _actionButtonsService = actionButtonsService;
            _productRateService = productRateService;

        }

        // Get
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();
            if(id.HasValue)
                PaperMillProfile = await _paperMillService.GetPaperMillProfile(id.Value);

            if (PaperMillProfile == null)
                return NotFound();


            PaperMillProfileDetails = _paperMillService.GetPaperMillProfileDetails(PaperMillProfile.Id);

            PaperMillProfile.TotalAmount = PaperMillProfileDetails.Sum(x => x.AmountEachPiece);
            PaperMillProfile.TotalPCSCount = PaperMillProfileDetails.Sum(x => x.ConsPcsYear);
            PaperMillProfile.TotalConsAmtPerYear = PaperMillProfileDetails.Sum(x => x.ConsAmtYear);

            Region = PaperMillProfile.Region;
            ActionButtons = _actionButtonsService.GetActionButtons(Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63"));

            PopulateViewData();
            return Page();
        }

        public JsonResult OnGetProductRate(string fabricId)
        {
            Double askingRate = 0;
            if (!string.IsNullOrWhiteSpace(fabricId) && !string.Equals(fabricId, "undefined"))
            {
                ProductRate rate = _productRateService.GetProductRate(Guid.Parse(fabricId));

                if (rate != null)
                    askingRate = rate.AskingRate;
                else
                    _toastNotification.AddWarningToastMessage("No rate defined for selected Fabric.");
            }
            else
                _toastNotification.AddInfoToastMessage("Fabric rate is not found. Please select Fabric.");

            return new JsonResult(askingRate);
        }

        // Post
        public JsonResult OnPostUpdateMillProfileDetails([FromBody]PaperMillProfileViewModel dto)
        {
            string message = string.Empty;
            Guid statusId = Guid.Empty;
            statusId = _statusService.GetStatusId(dto.buttonText);
            Guid paperMillProfileId = _paperMillService.UpdatePaperProfileDetails(dto.PaperMillProfileJson);
            int result = _paperMillService.UpdatePapaerProfile(paperMillProfileId, dto.MillJson, dto.RegionJson, User.Identity.Name);

            ActionButtons = _actionButtonsService.GetActionButtons(Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63"));

            if(result > 0)
                _toastNotification.AddSuccessToastMessage("Paper mill profile has been updated successfully");
            else
                message = "Something went wrong";

            return new JsonResult(message);

        }

        private void PopulateViewData()
        {
            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Name");
        }

        private bool PaperMillProfileExists(Guid id)
        {
            return _context.PaperMillProfile.Any(e => e.Id == id);
        }
    }
}
