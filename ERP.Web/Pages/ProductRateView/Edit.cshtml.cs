using System;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using NToastNotify;

namespace ERP.Pages.ProductRateView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRateService _productRateService;
        private readonly IToastNotification _toastNotification;

        public EditModel(ApplicationDbContext context, IProductRateService productRateService, IToastNotification toastNotification)
        {
            _context = context;
            _productRateService = productRateService;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public ProductRate ProductRate { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductRate = await _context.ProductRate
                .Include(p => p.Fabric).FirstOrDefaultAsync(m => m.Id == id);

            if (ProductRate == null)
            {
                return NotFound();
            }
            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int result = await _productRateService.UpdateProductRate(ProductRate);

            if (result > 0)
                _toastNotification.AddSuccessToastMessage("Product rate has been successfully udpated.");
            else
                _toastNotification.AddErrorToastMessage("Something went wrong.");

            return RedirectToPage("./Index");
        }
    }
}
