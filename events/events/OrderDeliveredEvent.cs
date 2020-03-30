using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.events
{
    public class OrderDeliveredEvent : EventArgs
    {
        public OrderDeliveredEvent(string orderId)
        {
            this.orderId = orderId;
        }

        public String orderId { get; }
    }
}
