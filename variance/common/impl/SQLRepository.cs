using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;

namespace csharp_concepts.variance.common.impl
{
    public class SQLRepository : Repository
    {
        public void create()
        {
            Console.WriteLine("creating using SQLRepository");
        }

        public void delete()
        {
            Console.WriteLine("deleting using SQLRepository");
        }

        public void read()
        {
            Console.WriteLine("reading using SQLRepository");
        }

        public void update()
        {
            Console.WriteLine("updating using SQLRepository");
        }
    }
}
