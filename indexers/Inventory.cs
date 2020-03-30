using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.indexers
{
    public class Inventory
    {
        public Inventory() {
            products = new List<Product>();
        }
        public List<Product> products { get; set; }

        public Product this[int productId] {
            get {
                return products.Find(product => product.id.Equals(productId));
            }
        }

        public Product this[String productName]
        {
            get
            {
                return products.Find(product => product.name.Equals(productName));
            }
        }
    }
}
