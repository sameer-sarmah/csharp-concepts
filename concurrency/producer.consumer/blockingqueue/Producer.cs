using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace csharp_concepts.concurrency.producer.consumer.blockingqueue
{
    public class Producer
    {
        private BlockingCollection<int> queueToPublish;

        public Producer(BlockingCollection<int> queue) {
            this.queueToPublish = queue;
        }

        public void produce() {

            Random random = new Random();
            var item = random.Next(0, 1000);
            Thread.Sleep(random.Next(500, 3000));
            Console.WriteLine($"added item {item} in thread {Thread.CurrentThread.ManagedThreadId}");
            queueToPublish.Add(item);
        }
    }
}
