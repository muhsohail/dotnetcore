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
    public class FabricERPClient : ERPClient
    {
        public FabricERPClient(HttpClient client, IConfiguration configuration) :
                base(client, configuration)
        {
        }

        public async Task<List<Fabric>> GetFabrics()
        {
            var response = await Client.GetAsync("api/consignment");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<Fabric>>();

            return result;
        }

        public async Task<string> GetFabricDescription(Guid fabricId)
        {
            var response = await Client.GetAsync(string.Format("api/fabric/GetFabricDescription/{0}", fabricId));
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<string>();

            return result;
        }
    }
}
