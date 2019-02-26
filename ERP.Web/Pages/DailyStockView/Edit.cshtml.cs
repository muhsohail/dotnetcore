using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using NToastNotify;

namespace ERP.Pages.DailyStockView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IDailyStockService _dailyStockService;
        private readonly IToastNotification _toastNotification;
        private readonly IActionButtonsService _actionButtonsService;

        public EditModel(
            ApplicationDbContext context,
            IDailyStockService dailyStockService,
            IToastNotification toastNotification,
            IActionButtonsService actionButtonsService)
        {
            _context = context;
        }

        [BindProperty]
        public DailyStock DailyStock { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DailyStock dailyStock = await _dailyStockService.GetDailyStockById(id.Value);

            if (DailyStock == null)
                return NotFound();

            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Id");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Id");

            ActionButtons = _actionButtonsService.GetActionButtons(Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63"));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int result = 0;
            result = await _dailyStockService.UpdateDailyStock(DailyStock);

            if (result > 0)
                _toastNotification.AddSuccessToastMessage("Daily Stock has been successfully updated.");
            else
                _toastNotification.AddErrorToastMessage("Something went wrong.");

            return RedirectToPage("./Index");
        }
    }
}
