using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ERP.WebApi.TypedClient.Base;
using Microsoft.Extensions.Configuration;
using Models;

namespace ERP.WebApi.TypedClient
{
    public class ERPClientService : ERPClient
    {
        public ERPClientService(HttpClient client, IConfiguration configuration)
            : base(client, configuration)
        {

        }

        public async Task<IList<City>> GetCities()
        {
            var response = await Client.GetAsync("api/city");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<IList<City>>();

            return result;
        }

        public async Task<City> GetCityById(Guid Id)
        {
            var response = await Client.GetAsync(string.Format("api/city/GetCityById/{0}", Id));
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<City>();

            return result;
        }
    }
}
