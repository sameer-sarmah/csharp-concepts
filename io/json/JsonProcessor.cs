using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using csharp_concepts.io.json.model;
using Newtonsoft.Json;

namespace csharp_concepts.io.json
{
    public class JsonProcessor
    {
        public static void process() {
            

            Country india = new Country();
            india.isoCode ="IN";
            india.name = "India";
            Countries countries = new Countries();
            countries.countries = new List<Country> { india};
            string serializedContent = JsonConvert.SerializeObject(countries, Formatting.Indented);

            Console.WriteLine(serializedContent);
            string jsonContent = File.ReadAllText("./../../../io/files/countries.json");
            countries = JsonConvert.DeserializeObject<Countries>(jsonContent);
            Console.WriteLine(countries);
        }
    }
}
