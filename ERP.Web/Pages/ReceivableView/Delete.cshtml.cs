using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.ReceivableView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Receivable Receivable { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Receivable = await _context.Receivables
                .Include(r => r.CPMPerson)
                .Include(r => r.Mill).FirstOrDefaultAsync(m => m.Id == id);

            if (Receivable == null)
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

            Receivable = await _context.Receivables.FindAsync(id);

            if (Receivable != null)
            {
                _context.Receivables.Remove(Receivable);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
