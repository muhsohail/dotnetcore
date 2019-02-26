using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace ERP.Pages.DesignationView
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
        public Designation Designation { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Designation.IsActive = true;
            _context.Designation.Add(Designation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}