using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.DesignationView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Designation> Designation { get;set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
                Designation = await _context.Designation.ToListAsync();
            else
                Designation = await _context.Designation.Where(x => x.IsActive).ToListAsync();
        }
    }
}
