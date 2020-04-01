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

        public string category { get; set; }

        public string description { get; set; }

        public bool discontinued { get; set; }

        [Column("standard_cost",TypeName = "decimal(5,2)")]
        public decimal? standardCost { get; set; }
        [Column("list_price", TypeName = "decimal(5,2)")]
        public decimal? listPrice { get; set; }

        public string name { get; set; }

        [Column("quantity_per_unit")]
        public string quantityPerUnit { get; set; }
        
        [Column("minimum_reorder_quantity", TypeName = "decimal(5,2)")]
        public decimal minimumReorderQuantity { get; set; }
        
        
    }
}
