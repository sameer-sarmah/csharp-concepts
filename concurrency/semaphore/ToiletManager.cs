using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharp_concepts.concurrency.semaphore
{
    class ToiletManager
    {
        public static void manage() {

            Semaphore availableTiolets = new Semaphore(3,3);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            var peopleNames = new List<string> { "Torres","Sachin","Rafa","Roger","Vettel"};
            var people = peopleNames.ConvertAll((name) => new Person(name, availableTiolets));
            var tasks = new List<Task>();
            people.ForEach((person) => {
                tasks.Add(Task.Factory.StartNew(() => person.useToilet()));
            });
            Task.WaitAll(tasks.ToArray());
        }
    }

    class Person {
        private string name;
        Semaphore availableToilets;

        public Person(string name, Semaphore availableTiolets) {
            this.name = name;
            this.availableToilets = availableTiolets;
        }

        public void useToilet() {
            Console.WriteLine($"{name} is trying to acquire a toilet in thread {Thread.CurrentThread.ManagedThreadId}");
            availableToilets.WaitOne();
            Console.WriteLine($"{name} has occupied a toilet");
            Thread.Sleep(new Random().Next(1000, 4000));
            availableToilets.Release();
            Console.WriteLine($"{name} has released the toilet");
        }


    }
}
