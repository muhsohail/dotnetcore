using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace ERP.Pages.CityView
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ERPClientService _erpClientService;

        public IndexModel(ApplicationDbContext context, IHttpClientFactory clientFactory, ERPClientService erpClientService)
        {
            _context = context;
            _clientFactory = clientFactory;
            _erpClientService = erpClientService;
        }

        public IList<City> City { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                City = await _erpClientService.GetCities();
            }
            catch (HttpRequestException)
            {
                City = Array.Empty<City>();
            }
        }
    }
}
