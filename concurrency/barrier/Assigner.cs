using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csharp_concepts.concurrency.barrier.api;
using csharp_concepts.concurrency.barrier.impl;

namespace csharp_concepts.concurrency.barrier
{
   public class Assigner
    {


        private static void routineOfAPerson(Person person, Barrier barrier, IEvent eventToAttend) {
            Random random = new Random();
            int value = random.Next(1,10);
            if (value >= 5)
            {
                Thread.Sleep(random.Next(500, 3000));
                Console.WriteLine($"{person.GetName()} has joined {eventToAttend.GetName()}");
                barrier.SignalAndWait();
            }
            else {
                Console.WriteLine($"{person.GetName()} won't be able to join {eventToAttend.GetName()}");
                barrier.RemoveParticipant();
            }
        }

        public static List<Task> decideWhoCanJoinEvent(List<Person> peopleToJoinAsPlanned, Barrier barrier, IEvent eventToAttend) {
            var tasks =new List<Task>();
            peopleToJoinAsPlanned.ForEach((person)=> {
                tasks.Add(Task.Factory.StartNew(() =>  routineOfAPerson (person,barrier,eventToAttend)));
            });
            return tasks;
        }

        public static List<Task> lateEntry(List<Person> peopleWhoDecidedToJoinLater, Barrier barrier, IEvent eventToAttend)
        {
            var tasks = new List<Task>();
            peopleWhoDecidedToJoinLater.ForEach((person) => {
                tasks.Add(Task.Factory.StartNew(() => {
                    barrier.AddParticipant();
                    Console.WriteLine($"{person.GetName()} has joined {eventToAttend.GetName()}");
                    barrier.SignalAndWait();
                }));
            });
            return tasks;
        }

    }
}
