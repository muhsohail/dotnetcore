using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.PersonView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
                Person = await _context.Person.ToListAsync();
            else
                Person = await _context.Person.Where(x => x.IsActive).ToListAsync();
        }
    }
}
