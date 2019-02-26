using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.MillView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Mill> Mill { get; set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
            {
                Mill = await _context.Mills
                      .Include(m => m.CPMPerson)
                      .Include(m => m.City)
                      .Include(m => m.MangerPerson)
                      .Include(m => m.MechanicalPerson)
                      .Include(m => m.Person).ToListAsync();
            }
            else
            {
                Mill = await _context.Mills
                .Include(m => m.CPMPerson)
                .Include(m => m.City)
                .Include(m => m.MangerPerson)
                .Include(m => m.MechanicalPerson)
                .Include(m => m.Person).Where(x => x.IsActive).ToListAsync();
            }



        }
    }
}
