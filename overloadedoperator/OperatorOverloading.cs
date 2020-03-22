using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using csharp_concepts.domain;

namespace csharp_concepts
{
    class OperatorOverloading
    {
        public static void operatorOverloadingDemo()
        {
            NumberWrapper ten = new NumberWrapper(10);
            NumberWrapper twenty = new NumberWrapper(20);
            NumberWrapper result = ten + twenty;
            Console.WriteLine($"the addition of {ten.GetValue()} and {twenty.GetValue()}  is {result.GetValue()} ");
        }
    }

    
}
