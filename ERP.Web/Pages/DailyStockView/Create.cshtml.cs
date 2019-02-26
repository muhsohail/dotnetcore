using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using NToastNotify;

namespace ERP.Pages.DailyStockView
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IDailyStockService _dailyStockService;
        private readonly IToastNotification _toastNotification;
        private readonly IActionButtonsService _actionButtonsService;

        [BindProperty]
        public DailyStock DailyStock { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }

        public CreateModel(ApplicationDbContext context, IDailyStockService dailyStockService, IToastNotification toastNotification, IActionButtonsService actionButtonsService)
        {
            _context = context;
            _dailyStockService = dailyStockService;
            _toastNotification = toastNotification;
            _actionButtonsService = actionButtonsService;
        }

        public IActionResult OnGet()
        {
            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");

            ActionButtons = _actionButtonsService.GetActionButtons(Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63"));
            
            // TODO make it better
            ActionButtons = ActionButtons.Where(x => x.ButtonText != "Save As Draft").ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string submit)
        {
            if (string.Equals(submit, "Cancel"))
                return RedirectToPage("./Index");
            else
            {
                int result = 0;
                if (!ModelState.IsValid)
                {
                    ActionButtons = _actionButtonsService.GetActionButtons(Guid.Parse("58e07c1d-f068-4a34-2b80-08d64cccfc63"))
                                    .Where(x => x.ButtonText != "Save As Draft").ToList();
                    ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
                    ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");

                    return Page();
                }

                result = await _dailyStockService.AddDailyStock(DailyStock);
                if (result > 0)
                    _toastNotification.AddSuccessToastMessage("Daily Stock has been successfully added..");
                else
                    _toastNotification.AddErrorToastMessage("Something went wrong.");

            }


            return RedirectToPage("./Index");
        }
    }
}