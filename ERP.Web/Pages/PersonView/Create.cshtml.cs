using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.PersonView
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // TODO Move it to API Controller
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Person.IsActive = true;
            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            
        }
    }
}