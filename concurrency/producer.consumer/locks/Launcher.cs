using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace csharp_concepts.concurrency.producer.consumer.locks
{
    class Launcher
    {
        public static void launch()
        {
            Queue<int> queue = new Queue<int>(5);
            var tasks = new List<Task>();
            for (var i = 0; i < 20; i++)
            {

                tasks.Add(Task.Factory.StartNew(() => {
                    Producer producer = new Producer(queue,5);
                    producer.produce();
                }));
                tasks.Add(Task.Factory.StartNew(() => {
                    Consumer consumer = new Consumer(queue,5);
                    consumer.consume();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
