using System;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using NToastNotify;

namespace ERP.Pages.MillView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRateService _productRateService;
        private readonly IToastNotification _toastNotification;
        private readonly IMillService _millService;

        public EditModel(
            ApplicationDbContext context, 
            IProductRateService productRateService, 
            IToastNotification toastNotification,
            IMillService millService)
        {
            _context = context;
            _productRateService = productRateService;
            _toastNotification = toastNotification;
            _millService = millService;
        }

        [BindProperty]
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
           ViewData["CPMId"] = new SelectList(_context.Person, "Id", "Name");
           ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
           ViewData["MangerId"] = new SelectList(_context.Person, "Id", "Name");
           ViewData["MechanicalId"] = new SelectList(_context.Person, "Id", "Name");
           ViewData["MDId"] = new SelectList(_context.Person, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Mill.IsActive = true;
            _context.Attach(Mill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MillExists(Mill.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MillExists(Guid id)
        {
            return _context.Mills.Any(e => e.Id == id);
        }
    }
}
