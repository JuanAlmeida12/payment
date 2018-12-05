using System.Net.Http;
using braspag.Models;
using System.Text;
using System;
using System.Threading.Tasks;

namespace braspag.Util
{
    public static class BrasPagUtil
    {
        private static readonly HttpClient client = new HttpClient();
        private const string API_URL = "https://apisandbox.braspag.com.br/v2/sales";
        private const string API_QUERY = "https://apiquerysandbox.braspag.com.br/v2/sales";
        static BrasPagUtil()
        {
            client.DefaultRequestHeaders.Add("MerchantId", "ba6ce2f7-d8ab-4fb3-9065-d280736154fc");
            client.DefaultRequestHeaders.Add("MerchantKey", "KMGWYARYRZCXVUGFXRRSRTIHAOKSCQYSZHKRDULA");
        }

        public async static Task<string> newOrder(OrderViewModel order)
        {            
            var content = new StringContent(order.toJson(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(API_URL, content);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async static Task<string> cancelOrder(string PaymentId)
        {
            
            var content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(API_URL + "/" + PaymentId + "/void", content);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }

        public async static Task<string> getOrder(string PaymentId)
        {
            Console.WriteLine(API_URL + "/" + PaymentId);
            HttpResponseMessage response = await client.GetAsync(API_QUERY + "/" + PaymentId);
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}