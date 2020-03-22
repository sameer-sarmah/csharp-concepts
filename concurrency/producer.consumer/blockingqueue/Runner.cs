using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharp_concepts.concurrency.producer.consumer.blockingqueue
{
    public class Runner
    {
        public static void launch() {
            BlockingCollection<int> queue = new BlockingCollection<int>(5);
            var tasks = new List<Task>();
            for (var i=0;i<50;i++) {

                tasks.Add(Task.Factory.StartNew(()=>{
                    Producer producer = new Producer(queue);
                    producer.produce();
                }));
                tasks.Add(Task.Factory.StartNew(() => {
                    Consumer consumer = new Consumer(queue);
                    consumer.consume();
                }));
            }
            Task.WaitAll(tasks.ToArray());
        }
    }
}
