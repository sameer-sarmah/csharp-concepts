using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.attributes
{
    [AttributeUsage(AttributeTargets.Class)]
   public class DomainModelAttribute : Attribute
    {
        public string domain { get; set; }
    }
}
