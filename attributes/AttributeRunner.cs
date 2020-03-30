using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace csharp_concepts.attributes
{
    public class AttributeRunner
    {
        public static void fetchAllDomainModels() {
            IEnumerable<Type> typesInTheAssembly = from t in Assembly.GetExecutingAssembly().GetTypes()
                                     where t.GetCustomAttribute<DomainModelAttribute>() != null
                                     select t;
            Dictionary<string, List<Type>> domainToObject = new Dictionary<string, List<Type>>();

            foreach (Type type in typesInTheAssembly) {
                Console.WriteLine(type.FullName);
                DomainModelAttribute decorator = type.GetCustomAttribute<DomainModelAttribute>();
                var domain = decorator.domain;
                if (domainToObject.ContainsKey(domain)) {
                    domainToObject.GetValueOrDefault(domain).Add(type);
                }
                else {
                    List<Type> types = new List<Type>();
                    types.Add(type);
                    domainToObject.Add(domain,types);
                }
                
            }

            Dictionary<string, List<Type>>.KeyCollection keys = domainToObject.Keys; 
            foreach (string key in keys)
            {
                List<string> types = domainToObject.GetValueOrDefault(key).ConvertAll((type) =>
                {
                    return type.FullName;
                });
                Console.WriteLine($"key is {key}, values are {string.Join(",",types)} ");
            }
            

           
        }
    }
}
