using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace csharp_concepts.util
{
    public class Util
    {
        public static string getProductByID(string id, HttpClient client) {
            string url = $"https://services.odata.org/Northwind/Northwind.svc/Products({id})?$format=json";
            Task<HttpResponseMessage> response = client.GetAsync(url);
            HttpContent content = response.Result.Content;
            Task<string> jsonStrTask =  content.ReadAsStringAsync();
            return jsonStrTask.Result;
        }


        public static int getProductsCount( HttpClient client)
        {
            string url = $"https://services.odata.org/Northwind/Northwind.svc/Products/$count";
            Task<HttpResponseMessage> response = client.GetAsync(url);
            HttpContent content = response.Result.Content;
            Task<string> countTask = content.ReadAsStringAsync();
            return int.Parse(countTask.Result);
        }

        public static async Task<int> getProductsCountAsync(HttpClient client) {
            Func<int> countProvider = () => getProductsCount(client);
            var fetchCountTask = Task<int>.Factory.StartNew(countProvider);
            int count = await fetchCountTask;
            Console.WriteLine($"fetchCountTask is completed: ${fetchCountTask.IsCompletedSuccessfully}");
            return count;
        }

        public static async Task<string> getProductByIDAsync(string id, HttpClient client)
        {
            Func<string> productProvider = () => getProductByID(id,client);
            var fetchProductTask = Task<string>.Factory.StartNew(productProvider);
            string productJSON = await fetchProductTask;
            Console.WriteLine($"fetchProductTask is completed: ${fetchProductTask.IsCompletedSuccessfully}");
            return productJSON;
        }
    }
}
