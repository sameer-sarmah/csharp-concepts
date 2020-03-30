using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace csharp_concepts.indexers
{
   public class Product
    {
        public Product(int id, string name, string description, double price)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }


        
    }
}
