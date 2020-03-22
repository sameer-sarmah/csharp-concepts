using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.concurrency.barrier.api;

namespace csharp_concepts.concurrency.barrier.impl
{
    public class PartyEvent : IEvent
    {
        private DateTime dateTime;
        private Address address;

        public PartyEvent(DateTime dateTime, Address address)
        {
            this.dateTime = dateTime;
            this.address = address;
        }

        public Address GetAddress()
        {
            return address;
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }

        public string GetName()
        {
            return this.GetType().Name;
        }
    }
}
