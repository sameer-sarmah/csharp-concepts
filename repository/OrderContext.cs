using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using csharp_concepts.entity;
using System.Data.Entity;

//System.Data.Entity represents the new EF Core
//System.Data.Entity represents EF6
namespace csharp_concepts.repository
{
    public class OrderContext :  DbContext
    {
        public OrderContext(string connectionString) : base(connectionString)
        {
             Database.SetInitializer<OrderContext>(new DropCreateDatabaseAlways<OrderContext>());
        }

        public  DbSet<Address> Address { get; set; }
        public  DbSet<Customer> Customer { get; set; }
        public  DbSet<Employee> Employee { get; set; }
        public  DbSet<Product> Product { get; set; }
        public  DbSet<Shipper> Shipper { get; set; }
        public  DbSet<OrderStatus> OrderStatus { get; set; }
        public  DbSet<OrderItem> OrderItem { get; set; }
        public  DbSet<Order> Order { get; set; }

    }
}
