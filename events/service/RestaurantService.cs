using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using csharp_concepts.events.handler;

namespace csharp_concepts.events.service
{
   public class RestaurantService
    {
        private Events events;

        public RestaurantService(Events events)
        {
            this.events = events;
        }

        public void handleOrderCreatedEvent(OrderCreatedEvent orderCreatedEvent)
        {
            Console.WriteLine($"order created by:{ orderCreatedEvent.customer.name}");
            Thread.Sleep(2000);
            events.publishOrderPreparedEvent(orderCreatedEvent.orderId, orderCreatedEvent.customer, orderCreatedEvent.restaurant);
        }

        public void handleOrderDeliveredEvent(OrderDeliveredEvent orderDeliveredEvent)
        {
            Console.WriteLine($"order {orderDeliveredEvent.orderId} delivered");
        }
    }
}
