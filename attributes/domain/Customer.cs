using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace csharp_concepts.attributes.domain
{
    [DomainModelAttribute(domain = "banking")]
   public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; }
 
        public string lastName { get; set; }
        public string email { get; set; }

        public Address address { get; set; }
    }
}
