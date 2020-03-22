using System;
using System.Collections.Generic;
using System.Text;
using csharp_concepts.variance.common.api;

namespace csharp_concepts.variance.common.impl
{
    public class NoSQLRepository : Repository
    {
        public void create()
        {
            Console.WriteLine("creating using NoSQLRepository");
        }

        public void delete()
        {
            Console.WriteLine("deleting using NoSQLRepository");
        }

        public void read()
        {
            Console.WriteLine("reading using NoSQLRepository");
        }

        public void update()
        {
            Console.WriteLine("updating using NoSQLRepository");
        }
    }
}
