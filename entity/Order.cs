using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace csharp_concepts.entity
{
   public class Order
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("employee_id")]
        public Employee employee { get; set; }
        [ForeignKey("customer_id")]
        public Customer customer;
        [ForeignKey("shipped_address")]
        public Address address;
        [ForeignKey("shipper_id")]
        public Shipper shipper;
        [ForeignKey("status_id")]
        public OrderStatus orderStatus;
        [Column(name: "order_date")]

        public DateTime orderDate;

        [Column(name: "shipped_date")]

        public DateTime shippedDate;

        [Column("paid_date")]

        public DateTime paidDate;


        [Column( "shipping_fee")]

        public double shippingFee;

        public double taxes;

        [Column( "payment_type")]

        public String paymentType;
    }
}
