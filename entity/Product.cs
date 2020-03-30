using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace csharp_concepts.entity
{
   public class Product
    {
        [Key]
        public int id { get; set; }
        [Column("product_name")]
        public string name { get; set; }
        public string description { get; set; }
        [Column("standard_cost")]
        public double standardCost { get; set; }
        [Column("list_price")]
        public double listPrice { get; set; }

        [Column("quantity_per_unit")]
        public string quantityPerUnit { get; set; }
        
        public bool discontinued { get; set; }
        [Column("minimum_reorder_quantity")]
        public int minimumReorderQuantity { get; set; }
        public string category { get; set; }
        
    }
}
