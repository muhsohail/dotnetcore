using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Areas.Application.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Fabric> Fabric { get; set; }

        public async Task OnGetAsync()
        {

            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
            {
                Fabric = await _context.Fabrics
                .Include(f => f.FabricType)
                .Include(f =>f.FabricCode)
                .ToListAsync();
            }
            else
            {
                Fabric = await _context.Fabrics
                    .Include(f => f.FabricType)
                    .Include(f => f.FabricCode)
                    .Where(x => x.IsActive)
                    .ToListAsync();
            }
        }
    }
}
