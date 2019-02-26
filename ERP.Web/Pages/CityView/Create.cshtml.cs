using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Newtonsoft.Json;

namespace ERP.Pages.CityView
{
    //[Tracking]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public CreateModel(ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public IActionResult OnGet()
        {
            ViewData["RegionId"] = new SelectList(_context.Region.Where(x => x.IsActive), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public City City { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _clientFactory.CreateClient("ERPClient");
            string values = JsonConvert.SerializeObject(City);
            var stringContent = new StringContent(values, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/City", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}