using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.ProductRateView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRateService _productRateService;

        public IndexModel(ApplicationDbContext context, IProductRateService productRateService)
        {
            _context = context;
            _productRateService = productRateService;
        }

        public IList<ProductRate> ProductRate { get; set; }

        public async Task OnGetAsync()
        {

            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
            {

                ProductRate = await _context.ProductRate
                    .Include(p => p.Fabric)
                    .ToListAsync();
            }
            else
            {

                ProductRate = await _context.ProductRate
                    .Include(p => p.Fabric)
                    .Where(x => x.IsActive)
                    .ToListAsync();
            }
        }
    }
}
