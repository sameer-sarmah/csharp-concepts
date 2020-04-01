using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace csharp_concepts.entity
{
    [Table("order_status")]
   public class OrderStatus
    {
        [Key]
        public int id { get; set; }
        public string status { get; set; }
    }
}
