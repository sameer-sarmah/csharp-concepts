using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace csharp_concepts.concurrency.producer.consumer.blockingqueue
{
    class Consumer
    {
        private BlockingCollection<int> queueToConsume;

        public Consumer(BlockingCollection<int> queue)
        {
            this.queueToConsume = queue;
        }

        public void consume()
        {

            Random random = new Random();
            Thread.Sleep(random.Next(500, 1500));
            var item = queueToConsume.Take();
            Console.WriteLine($"consumed item {item} in thread {Thread.CurrentThread.ManagedThreadId}");
            
        }
    }
}
