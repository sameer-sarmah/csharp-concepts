using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csharp_concepts.util;

namespace csharp_concepts.concurrency.countdownlatch
{
    class HttpCallCountDownLatch
    {
        public static void httpCallParallelly() {
            HttpClient client = new HttpClient();
            CountdownEvent countdown = new CountdownEvent(2);
            var fetchProductsCountTask = getProductsCount(client,countdown);
            var fetchProductTask = getProduct("1", client, countdown);
            countdown.Wait();
            if (fetchProductTask.IsCompletedSuccessfully && fetchProductsCountTask.IsCompletedSuccessfully)
            {
                Console.WriteLine($"products count is {fetchProductsCountTask.Result}");
                Console.WriteLine($"product is {fetchProductTask.Result}");
            }
        }


        public static Task<int> getProductsCount(HttpClient client,CountdownEvent countdown) {

     
            Func<int> countProvider = () => util.Util.getProductsCount(client);
            var fetchProductsCountProduct = new TaskCompletionSource<int>();
            Task.Factory.StartNew(() =>
            {
                int productCount = countProvider();
                fetchProductsCountProduct.SetResult(productCount);
                countdown.Signal();
            });
            var fetchProductsCountTask = fetchProductsCountProduct.Task;
            return fetchProductsCountTask;


        }

        public static Task<string> getProduct(string id,HttpClient client, CountdownEvent countdown)
        {

            Func<string> productProvider = () => util.Util.getProductByID(id, client);
            var fetchProductPromise = new TaskCompletionSource<string>();
            Task.Factory.StartNew(() =>
            {
                string product = productProvider();
                fetchProductPromise.SetResult(product);
                countdown.Signal();
            });
            var fetchProductTask = fetchProductPromise.Task;
            return fetchProductTask;


        }
    }
}
