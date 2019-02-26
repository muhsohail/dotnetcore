using System;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.DesignationView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Designation.IsActive = true;
            _context.Attach(Designation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignationExists(Designation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DesignationExists(Guid id)
        {
            return _context.Designation.Any(e => e.Id == id);
        }
    }
}
