using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.events.domain;
using csharp_concepts.events.handler;
using csharp_concepts.events.service;

namespace csharp_concepts.events
{
    public class EventsRunner
    {
        public static void createOrder() {

            Address customerAddress = new Address();
            customerAddress.address = "A804,Spring beauty Apartment";
            customerAddress.city = "bangalore";
            customerAddress.state = "karnataka";
            customerAddress.zip = "560037";

            Customer customer = new Customer();
            customer.name = "sameer";
            customer.address = customerAddress;

            Address restaurantAddress = new Address();
            restaurantAddress.address = "Moriz Brookfield";
            restaurantAddress.city = "bangalore";
            restaurantAddress.state = "karnataka";
            restaurantAddress.zip = "560037";

            Restaurant restaurant = new Restaurant();
            restaurant.address = restaurantAddress;
            restaurant.name = "Moriz";

            Events events = new Events();
            DeliveryService deliveryService = new DeliveryService(events);
            RestaurantService restaurantService = new RestaurantService(events);

            OrderCreatedEventHandler orderCreatedEventHandler = restaurantService.handleOrderCreatedEvent;
            OrderPreparedEventHandler orderPreparedEventHandler = deliveryService.handleOrderPreparedEvent;
            OrderPickedUpEventHandler orderPickedUpEventHandler = deliveryService.handleOrderPickedUpEvent;
            OrderDeliveredEventHandler orderDeliveredEventHandler = restaurantService.handleOrderDeliveredEvent;
            events.OrderCreated += orderCreatedEventHandler;
            events.OrderPrepared += orderPreparedEventHandler;
            events.OrderPickedUp += orderPickedUpEventHandler;
            events.OrderDelivered += orderDeliveredEventHandler;

            events.publishOrderCreatedEvent(Guid.NewGuid().ToString(), customer, restaurant);


        }
    }
}
