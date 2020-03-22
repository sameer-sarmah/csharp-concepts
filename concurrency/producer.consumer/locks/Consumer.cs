using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace csharp_concepts.concurrency.producer.consumer.locks
{
    class Consumer
    {
        private Queue<int> queueToConsume;
        private int limit;

        public Consumer(Queue<int> queue, int limit)
        {
            queueToConsume = queue;
            this.limit = limit;
        }

        public void consume()
        {
            
            Monitor.Enter(queueToConsume);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            while (queueToConsume.Count == 0)
            {
                Console.WriteLine($"waiting in thread {Thread.CurrentThread.ManagedThreadId} to consume item");
                Monitor.Wait(queueToConsume);
            }
            Random random = new Random();
            int  item = queueToConsume.Dequeue();
            Thread.Sleep(random.Next(500, 3000));
            Console.WriteLine($"item {item} consumed in thread {Thread.CurrentThread.ManagedThreadId}");
            Monitor.PulseAll(queueToConsume);
            Monitor.Exit(queueToConsume);

        }
    }
}
