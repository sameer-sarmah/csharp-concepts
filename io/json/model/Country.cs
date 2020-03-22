using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.io.json.model
{
   public class Country
    {
        public string name { get; set; }
        public string isoCode { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Country country &&
                   name == country.name &&
                   isoCode == country.isoCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, isoCode);
        }

        public override string ToString()
        {
            return $"name is :{name}, ISO code is: {isoCode}";
        }
    }
}
