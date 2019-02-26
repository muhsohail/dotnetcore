using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.WebApi;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Newtonsoft.Json;

namespace ERP.Pages.CityView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ERPClientService _erpClientService;

        public EditModel(ApplicationDbContext context, IHttpClientFactory clientFactory, ERPClientService erpClientService)
        {
            _context = context;
            _clientFactory = clientFactory;
            _erpClientService = erpClientService;
        }

        [BindProperty]
        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            ViewData["RegionId"] = new SelectList(_context.Region.Where(x => x.IsActive), "Id", "Name");

            if (id == null)
            {
                return NotFound();
            }
            City = await _erpClientService.GetCityById(id.Value);
            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _clientFactory.CreateClient("ERPClient");
            string values = JsonConvert.SerializeObject(City);
            var stringContent = new StringContent(values, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(string.Format("api/City/{0}", City.Id), stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");

        }

        private bool CityExists(Guid id)
        {
            return _context.City.Any(e => e.Id == id);
        }
    }
}
