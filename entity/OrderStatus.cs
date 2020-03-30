using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace csharp_concepts.entity
{
   public class OrderStatus
    {
        [Key]
        private int id { get; set; }
        private string status { get; set; }
    }
}
