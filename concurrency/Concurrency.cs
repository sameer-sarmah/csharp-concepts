using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csharp_concepts.util;

namespace csharp_concepts.concurrency
{
    class Concurrency
    {
        static readonly HttpClient client = new HttpClient();

        public static void threads(){
            string productProvider(string id) {
                return util.Util.getProductByID(id, client);
            }

            int countProvider() { 
                return util.Util.getProductsCount(client);
            }
            int count = 0;
            string product = "";
            var threadToGetCount = new Thread(() => { count = countProvider(); });
            threadToGetCount.Start();

            var threadToGetProduct = new Thread(() => { product = productProvider("1"); });
            threadToGetProduct.Start();

            List<Thread> threads = new List<Thread> { threadToGetCount , threadToGetProduct };
            threads.ForEach((thread) => thread.Join());
 
            Console.WriteLine($"products count is {count}");
            Console.WriteLine($"product is {product}");
            
        }

        //uses task parallel library,Task are kind of like Future in java
        public static void tasks()
        {
            Func<string> productProvider = () => util.Util.getProductByID("1", client);
            Func<int> countProvider = () => util.Util.getProductsCount(client);
            var fetchProductTask = new Task<string>(productProvider);
            fetchProductTask.Start();
            var fetchProductsCountTask = new Task<int>(countProvider);
            fetchProductsCountTask.Start();
            List<Task> tasks = new List<Task> { fetchProductTask, fetchProductsCountTask };
            Task.WaitAll(tasks.ToArray());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("tasks completed");
            if (fetchProductTask.IsCompletedSuccessfully && fetchProductsCountTask.IsCompletedSuccessfully)
            {
                Console.WriteLine($"products count is {fetchProductsCountTask.Result}");
                Console.WriteLine($"product is {fetchProductTask.Result}");
            }
        }

        public static void promises()
        {
            Func<string> productProvider = () => util.Util.getProductByID("1", client);
            Func<int> countProvider = () => util.Util.getProductsCount(client);
            var fetchProductPromise = new TaskCompletionSource<string>();
            Task.Factory.StartNew(() =>
            {
                string product = productProvider();
                fetchProductPromise.SetResult(product);
            });
            var fetchProductTask = fetchProductPromise.Task;
            var fetchProductsCountProduct = new TaskCompletionSource<int>();
            Task.Factory.StartNew(() =>
            {
                int productCount = countProvider();
                fetchProductsCountProduct.SetResult(productCount);
            });
            var fetchProductsCountTask = fetchProductsCountProduct.Task;
            List<Task> tasks = new List<Task> { fetchProductTask, fetchProductsCountTask };
            Task.WaitAll(tasks.ToArray());
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("tasks completed");
            if (fetchProductTask.IsCompletedSuccessfully && fetchProductsCountTask.IsCompletedSuccessfully)
            {
                Console.WriteLine($"products count is {fetchProductsCountTask.Result}");
                Console.WriteLine($"product is {fetchProductTask.Result}");
            }
        }

        public static void asyncAwait()
        {
            var fetchProductTask = Util.getProductByIDAsync("1",client: client);
            var fetchCountTask = Util.getProductsCountAsync(client);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"products count is {fetchProductTask.Result}");
            Console.WriteLine($"product is {fetchCountTask.Result}");
        }
    }
        
}
