using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.events.domain;

namespace csharp_concepts.events.handler
{
    public delegate void OrderCreatedEventHandler(OrderCreatedEvent orderCreatedEvent);
    public delegate void OrderPreparedEventHandler(OrderPreparedEvent orderPreparedEvent);
    public delegate void OrderPickedUpEventHandler(OrderPickedUpEvent orderPickedUpEvent);
    public delegate void OrderDeliveredEventHandler(OrderDeliveredEvent orderDeliveredEvent);
    public class Events
    {
        public event OrderCreatedEventHandler OrderCreated;
        public event OrderPreparedEventHandler OrderPrepared;
        public event OrderPickedUpEventHandler OrderPickedUp;
        public event OrderDeliveredEventHandler OrderDelivered;

        public void publishOrderCreatedEvent(string orderId,Customer customer, Restaurant restaurant)
        {
            OrderCreated?.Invoke(new OrderCreatedEvent(orderId, customer, restaurant));
        }

        public void publishOrderPickedUpEvent(string orderId, Customer customer,DeliveryAgent deliveryAgent)
        {
            OrderPickedUp?.Invoke(new OrderPickedUpEvent(orderId: orderId, customer:customer,deliveryAgent:deliveryAgent));
        }

        public void publishOrderPreparedEvent(string orderId, Customer customer, Restaurant restaurant)
        {
            OrderPrepared?.Invoke(new OrderPreparedEvent(orderId, customer, restaurant));
        }

        public void publishOrderDeliveredEvent(string orderId)
        {
            OrderDelivered?.Invoke(new OrderDeliveredEvent(orderId));
        }

    }

}
