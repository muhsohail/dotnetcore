using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.OrderView
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.Fabric)
                .Include(o => o.Mill)
                .Include(o => o.Region).FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
