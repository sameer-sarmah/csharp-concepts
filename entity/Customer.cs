using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace csharp_concepts.entity
{
   public class Customer
    {
        [Key]
        public int id { get; set; }
        [Column("first_name")]
        public string firstName { get; set; }
        [Column("last_name")]
        public string lastName { get; set; }
        public string email { get; set; }

        [ForeignKey("address_id")]
        public Address address { get; set; }
    }
}
