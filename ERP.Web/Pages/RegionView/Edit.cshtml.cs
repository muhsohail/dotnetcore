using System;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.RegionView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Region Region { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Region = await _context.Region.FirstOrDefaultAsync(m => m.Id == id);

            if (Region == null)
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
            Region.IsActive = true;
            _context.Attach(Region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(Region.Id))
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

        private bool RegionExists(Guid id)
        {
            return _context.Region.Any(e => e.Id == id);
        }
    }
}
