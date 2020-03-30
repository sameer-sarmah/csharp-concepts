using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace csharp_concepts.entity
{
    public class Shipper
    {
        [Key]
        public int id { get; set; }
        public string company { get; set; }
        [Column("web_page")]
        public string webpage { get; set; }
        public string email { get; set; }
        [ForeignKey("address_id")]
        public Address address { get; set; }
    }
}
