using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.RegionView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Region> Region { get; set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
                Region = await _context.Region.OrderBy(x =>x.RegionNo).ToListAsync();
            else
                Region = await _context.Region.OrderBy(x => x.RegionNo).Where(x => x.IsActive).ToListAsync();
        }
    }
}
