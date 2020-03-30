using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.events.domain;

namespace csharp_concepts.events
{
    public class OrderPickedUpEvent : EventArgs
    {
        public OrderPickedUpEvent(string orderId, Customer customer, DeliveryAgent deliveryAgent)
        {
            this.orderId = orderId;
            this.customer = customer;
            this.deliveryAgent = deliveryAgent;
        }

        public String orderId { get; }

        public Customer customer { get; }

        public DeliveryAgent deliveryAgent { get; }

    }
}
