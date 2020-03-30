using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_concepts.indexers
{
   public class IndexerDriver
    {
        public static void indexer() {
            Product milk = new Product(1,"Amul Milk","High in calcium",20);
            Product beer = new Product(2, "Bira Beer", "Low alcohol,but extremely smooth", 200);
            Product wheyProtein = new Product(3, "Whey Protein", "High in protein", 2000);
            List<Product> products = new List<Product> { milk ,beer,wheyProtein};
            Inventory inventory = new Inventory();
            inventory.products.AddRange( products);

            Product fetchedBeer = inventory[2];
            Console.WriteLine($"{fetchedBeer.name}");

            Product fetchedMilk = inventory[milk.name];
            Console.WriteLine($"{fetchedMilk.name}");
        }
    }
}
