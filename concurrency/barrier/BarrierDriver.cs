using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using csharp_concepts.concurrency.barrier.api;
using csharp_concepts.concurrency.barrier.impl;

namespace csharp_concepts.concurrency.barrier
{
    public class BarrierDriver
    {
        public static void launch() {
            //similar to phaser in java
            
            Person torres = new Person("torres");
            Person kohli = new Person("kohli");
            Person vettel = new Person("vettel");
            Person sachin = new Person("sachin");
            Person sameer = new Person("sameer");
            Person mayuri = new Person("mayuri");
            var peopleToJoinAsPlanned = new List<Person> { torres, kohli, vettel, sachin, sameer };
            var peopleWhoDecidedLater = new List<Person> { mayuri };
            Barrier barrier = new Barrier(peopleToJoinAsPlanned.Count);
            Address address = new Address(city:"Bangalore",street:"Indira Nagar",building:"Toit",zip:560048);
            DateTime dateTime = new DateTime(2020, 3, 20, 18, 30, 0);
            var tasks = new List<Task>();
            IEvent partyEvent = new PartyEvent(address:address,dateTime:dateTime);
            tasks.AddRange( Assigner.decideWhoCanJoinEvent(peopleToJoinAsPlanned,barrier, partyEvent));
            Thread.Sleep(3000);
            tasks.AddRange(Assigner.lateEntry(peopleWhoDecidedLater, barrier, partyEvent));
            Task.WaitAll(tasks.ToArray());
           
        }
    }


}
