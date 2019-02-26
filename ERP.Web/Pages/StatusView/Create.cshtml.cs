using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.StatusView
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
        public Status Status { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Status.IsActive = true;
            _context.Status.Add(Status);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}