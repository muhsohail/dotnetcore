using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace ERP.WebApi.TypedClient.Base
{
    public class ERPClient
    {
        public HttpClient Client { get; }
        public IConfiguration Configuration { get; }

        public ERPClient(HttpClient client, IConfiguration configuration)
        {
            Configuration = configuration;

            client.BaseAddress = new Uri(Configuration["hostUrl"]);
            client.DefaultRequestHeaders.Add("Accept",
                "application/json");
            client.DefaultRequestHeaders.Add("User-Agent",
                "ERPClient");
            client.DefaultRequestHeaders.Add("Handshake", "Handshaking");

            Client = client;
        }
    }
}
