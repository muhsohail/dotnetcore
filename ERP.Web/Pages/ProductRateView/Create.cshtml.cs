using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using NToastNotify;

namespace ERP.Pages.ProductRateView
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRateService _productRateService;
        private readonly IToastNotification _toastNotification;

        [BindProperty]
        public ProductRate ProductRate { get; set; }

        public CreateModel(ApplicationDbContext context, IProductRateService productRateService, IToastNotification toastNotification)
        {
            _context = context;
            _productRateService = productRateService;
            _toastNotification = toastNotification;
        }

        public IActionResult OnGet()
        {
            ViewData["FabricId"] = new SelectList(_context.Fabrics, "Id", "Code");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            int result = await _productRateService.AddProductRate(ProductRate);
            if (result > 0)
                _toastNotification.AddSuccessToastMessage("Product rate has been successfully added..");
            else
                _toastNotification.AddErrorToastMessage("Something went wrong.");

            return RedirectToPage("./Index");
        }
    }
}