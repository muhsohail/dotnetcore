using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.RegionView
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Region Region { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Region = await _context.Region.FirstOrDefaultAsync(m => m.Id == id);

            if (Region == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
