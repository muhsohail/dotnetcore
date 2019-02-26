using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace ERP.Pages.RegionView
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
        public Region Region { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Region.IsActive = true;
            _context.Region.Add(Region);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}