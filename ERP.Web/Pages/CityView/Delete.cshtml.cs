using System;
using System.Net.Http;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.CityView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public DeleteModel(
            ApplicationDbContext context, 
            IHttpClientFactory clientFactory
            )
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.FirstOrDefaultAsync(m => m.Id == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientFactory.CreateClient("ERPClient");
            var response = await client.DeleteAsync(string.Format("api/City/{0}", City.Id));

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}
