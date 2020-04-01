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
        public Customer customer { get; set; }

        [ForeignKey("shipped_address")]
        public Address address { get; set; }

        [ForeignKey("shipper_id")]
        public Shipper shipper { get; set; }

        [ForeignKey("status_id")]
        public OrderStatus orderStatus { get; set; }

        [Column(name: "order_date")]
        public DateTime orderDate { get; set; }

        [Column(name: "shipped_date")]
        public DateTime shippedDate { get; set; }

        [Column("paid_date")]
        public DateTime paidDate { get; set; }


        [Column( "shipping_fee")]
        public double shippingFee { get; set; }

        public double taxes { get; set; }

        [Column( "payment_type")]
        public string paymentType { get; set; }
    }
}
