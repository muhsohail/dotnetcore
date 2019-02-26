using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.StatusView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Status> Status { get;set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
                Status = await _context.Status.ToListAsync();
            else
                Status = await _context.Status.Where(x =>x.IsActive).ToListAsync();
        }
    }
}
