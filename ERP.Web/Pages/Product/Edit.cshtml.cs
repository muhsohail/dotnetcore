using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Areas.Application.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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
           ViewData["FabricTypeId"] = new SelectList(_context.FabricTypes, "Id", "Type");

            ViewData["FabricCodeId"] = new SelectList(_context.FabricCodes, "Id", "Code");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            string type = _context.FabricTypes.Where(x => x.Id == Fabric.FabricTypeId).FirstOrDefault().Type;
            string fabricCode = _context.FabricCodes.Where(x => x.Id == Fabric.FabricCodeId).FirstOrDefault().Code;

            Fabric.IsActive = true;
            Fabric.Code = string.Empty;
            Fabric.Code = string.Format("{0}/{1}", fabricCode, type);
            _context.Attach(Fabric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FabricExists(Fabric.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private bool FabricExists(Guid id)
        {
            return _context.Fabrics.Any(e => e.Id == id);
        }
    }
}
