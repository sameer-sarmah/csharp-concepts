using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.events.domain;

namespace csharp_concepts.events
{
    public class OrderPreparedEvent : EventArgs
    {
        public OrderPreparedEvent(string orderId, Customer customer, Restaurant restaurant)
        {
            this.orderId = orderId;
            this.customer = customer;
            this.restaurant = restaurant;
        }

        public String orderId { get; }

        public Customer customer { get; }

        public Restaurant restaurant { get; }

    }
}
