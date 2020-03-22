using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.concurrency.barrier.impl;

namespace csharp_concepts.concurrency.barrier.api
{
    public interface IEvent
    {
        public string GetName();
        public DateTime GetDateTime();

        public Address GetAddress();
    }
}
