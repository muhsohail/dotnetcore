using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.MillView
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Mill Mill { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mill = await _context.Mills
                .Include(m => m.CPMPerson)
                .Include(m => m.City)
                .Include(m => m.MangerPerson)
                .Include(m => m.MechanicalPerson)
                .Include(m => m.Person).FirstOrDefaultAsync(m => m.Id == id);

            if (Mill == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
