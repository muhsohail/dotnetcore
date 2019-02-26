using System;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
namespace ERP.Areas.Application.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
