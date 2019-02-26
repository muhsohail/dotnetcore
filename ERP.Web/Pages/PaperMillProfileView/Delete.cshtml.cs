using System;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using NToastNotify;

namespace ERP.Pages.PaperMillProfileView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaperMillService _paperMillService;
        private readonly IToastNotification _toastNotification;

        public DeleteModel(ApplicationDbContext context, IPaperMillService paperMillService, IToastNotification toastNotification)
        {
            _context = context;
            _paperMillService = paperMillService;
            _toastNotification = toastNotification;
    }

        [BindProperty]
        public PaperMillProfile PaperMillProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            if(id.HasValue)
                PaperMillProfile = await _paperMillService.GetPaperMillProfile(id.Value);

            if (PaperMillProfile == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            int result = 0;
            if (id.HasValue)
                result = await _paperMillService.DeletePaperMillProfile(id.Value);

            if(result > 0)
                _toastNotification.AddWarningToastMessage("The record has been successfully deleted.");
            else
                _toastNotification.AddWarningToastMessage("Something went wrong.");

            return RedirectToPage("./Index");
        }
    }
}
