using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using csharp_concepts.events.domain;
using csharp_concepts.events.handler;

namespace csharp_concepts.events.service
{
    public class DeliveryService
    {
        private Events events;

        public DeliveryService(Events events)
        {
            this.events = events;
        }
        public void handleOrderPreparedEvent(OrderPreparedEvent orderPreparedEvent)
        {

            Console.WriteLine($"order prepared for :{ orderPreparedEvent.customer.name}");
            DeliveryAgent deliveryAgent = new DeliveryAgent();
            deliveryAgent.name = "Mukesh";
            deliveryAgent.phone = "124122";
            Thread.Sleep(2000);
            events.publishOrderPickedUpEvent(orderPreparedEvent.orderId, orderPreparedEvent.customer,deliveryAgent);
        }

        public void handleOrderPickedUpEvent(OrderPickedUpEvent orderPickedUpEvent) {
            Console.WriteLine($"order picked up for delivery by agent :{ orderPickedUpEvent.deliveryAgent.name}");
            Thread.Sleep(2000);
            events.publishOrderDeliveredEvent(orderPickedUpEvent.orderId);
        }
    }
}
