
using csharp_concepts.entity;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

//MySql.Data.EntityFrameworkCore is not compatible with EF Core 3.0
//Microsoft.EntityFrameworkCore represents the new EF Core
//System.Data.Entity represents EF6
namespace csharp_concepts.repository
{
    public class OrderContext :  DbContext
    {
        public OrderContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseMySQL("server=localhost;user=root;database=dotnetnorthwind;port=3308;password=root");
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Database=dotnetnorthwind;Port=5432;Password=root");
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
