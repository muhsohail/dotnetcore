using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Areas.Application.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fabric Fabric { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fabric = await _context.Fabrics
                .Include(f => f.FabricType).FirstOrDefaultAsync(m => m.Id == id);

            if (Fabric == null)
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

            Fabric = await _context.Fabrics.FindAsync(id);

            if (Fabric != null)
            {

                Fabric.IsActive = false;
               // _context.Fabrics.Remove(Fabric);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
