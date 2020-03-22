using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace csharp_concepts.concurrency.producer.consumer.locks
{
    public class Producer
    {
        private Queue<int> queueToPublish;
        private int limit;

        public Producer(Queue<int> queue,int limit) {
            queueToPublish = queue;
            this.limit = limit;
        }

        public void produce() {
            
            Monitor.Enter(queueToPublish);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            while (queueToPublish.Count == limit) {
                Console.WriteLine($"waiting in thread {Thread.CurrentThread.ManagedThreadId} to add item");
                Monitor.Wait(queueToPublish);
            }
            Random random = new Random();
            var item = random.Next(0, 1000);
            Thread.Sleep(random.Next(500, 3000));
            Console.WriteLine($"added item {item} in thread {Thread.CurrentThread.ManagedThreadId}");
            queueToPublish.Enqueue(item);
            Monitor.PulseAll(queueToPublish);
            Monitor.Exit(queueToPublish);

        }

    }
}
