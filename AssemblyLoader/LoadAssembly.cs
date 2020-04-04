using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace csharp_concepts.AssemblyLoader
{
   public class LoadAssembly
    {
        public static void load()
        {
            AssemblyName entityFrameworkCore = new AssemblyName("Microsoft.EntityFrameworkCore");
            AssemblyLoadContext assemblyLoadContext = AssemblyLoadContext.Default;
            Assembly entityFrameworkCoreAssembly = assemblyLoadContext.LoadFromAssemblyName(entityFrameworkCore);
            Console.WriteLine(entityFrameworkCoreAssembly.Location);
        }
    }
}
