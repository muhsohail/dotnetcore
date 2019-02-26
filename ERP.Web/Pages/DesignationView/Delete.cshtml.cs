using System;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.DesignationView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Designation Designation { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Designation = await _context.Designation.FirstOrDefaultAsync(m => m.Id == id);

            if (Designation == null)
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

            Designation = await _context.Designation.FindAsync(id);

            if (Designation != null)
            {
                Designation.IsActive = false;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
