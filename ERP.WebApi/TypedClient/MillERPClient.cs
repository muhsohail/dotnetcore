using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ERP.WebApi.TypedClient.Base;
using Microsoft.Extensions.Configuration;
using Models;

namespace ERP.WebApi.TypedClient
{
    public class MillERPClient: ERPClient
    {
        public MillERPClient(HttpClient client, IConfiguration configuration) :
            base(client, configuration)
        {
        }
        public async Task<List<Mill>> GetMills()
        {
            var response = await Client.GetAsync("api/consignment");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<Mill>>();

            return result;
        }

        public async Task<Mill> GetMillByCode(string millCode)
        {
            var response = await Client.GetAsync(string.Format("api/consignment/GetMillByCode/{0}", millCode));
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<Mill>();

            return result;
        }
    }
}
