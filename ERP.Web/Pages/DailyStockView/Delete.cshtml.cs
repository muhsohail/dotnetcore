using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.DailyStockView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DailyStock DailyStock { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DailyStock = await _context.DailyStocks
                .Include(d => d.Fabric)
                .Include(d => d.Mill).FirstOrDefaultAsync(m => m.Id == id);

            if (DailyStock == null)
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

            DailyStock = await _context.DailyStocks.FindAsync(id);

            if (DailyStock != null)
            {
                _context.DailyStocks.Remove(DailyStock);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
