using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ERP.WebApi.TypedClient.Base;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;

namespace ERP.WebApi.TypedClient
{
    public class ConsginmentERPClient : ERPClient
    {
        public ConsginmentERPClient(HttpClient client, IConfiguration configuration) :
            base(client, configuration)
        {
        }

        public async Task<List<ConsignmentOrder>> GetConsignmentOrder()
        {
            var response = await Client.GetAsync("api/consignment");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<ConsignmentOrder>>();

            return result;
        }

        public async Task<List<ConsignmentOrder>> GetActiveConsignmentOrder()
        {
            var response = await Client.GetAsync("api/consignment/GetActiveConsignmentOrders");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<ConsignmentOrder>>();

            return result;
        }

        public async Task<List<ConsignmentOrderItem>> GetFormingWireConsignmentOrderItems()
        {
            var response = await Client.GetAsync("api/consignment/GetFormingWireConsignmentOrderItems");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<ConsignmentOrderItem>>();

            return result;
        }

        public async Task<List<ConsignmentOrderItem>> GetConsignmentOrderItemsByFabric(string fabric)
        {
            var response = await Client.GetAsync(string.Format("api/consignment/GetConsignmentOrderItemsByFabric/{0}", fabric));
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<ConsignmentOrderItem>>();

            return result;
        }

        public async Task<List<ConsignmentOrderItem>> GetConsignmentOrderItems()
        {
            var response = await Client.GetAsync("api/consignment/GetConsignmentOrderItems");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<ConsignmentOrderItem>>();

            return result;
        }

        public async Task<List<ConsignmentOrderItem>> GetApprovedConsignmentOrderItems()
        {
            var response = await Client.GetAsync("api/consignment/GetApprovedConsignmentOrderItems");
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<List<ConsignmentOrderItem>>();

            return result;
        }

        public async Task<int> CreateConsignmentOrder(ConsignmentOrder consignmentOrder)
        {
            string data = JsonConvert.SerializeObject(consignmentOrder);
            var stringContent = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("api/consignment", stringContent);
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<int>();

            return result;
        }


        public async Task<bool> DeleteConsignment(Guid Id)
        {
            var response = await Client.DeleteAsync(string.Format("api/consignment/{0}", Id));
            return response.IsSuccessStatusCode;
        }
    }
}
