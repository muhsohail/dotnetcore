using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.ProductRateView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductRate = await _context.ProductRate.FindAsync(id);

            if (ProductRate != null)
            {
                ProductRate.IsActive = false;
                //_context.ProductRate.Remove(ProductRate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
