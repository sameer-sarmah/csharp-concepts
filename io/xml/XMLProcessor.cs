using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using csharp_concepts.io.xml.model;

namespace csharp_concepts.io.xml
{
    public class XMLProcessor
    {
        public static void process() {

            Country india = new Country();
            india.isoCode = "IN";
            india.name = "India";

            Country norway = new Country();
            norway.isoCode = "NR";
            norway.name = "Norway";
            Countries countries = new Countries();
            countries.countries = new List<Country> { india , norway };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Countries));
            string tempFilePath = "./../../../io/files/countries-temp.xml";
            FileStream outputStream = File.Create(tempFilePath);
            xmlSerializer.Serialize(outputStream,countries);
            outputStream.Close();
            File.Delete(tempFilePath);

            string xmlContent = File.ReadAllText("./../../../io/files/countries.xml");
           var stringReader = new StringReader(xmlContent);
            
            countries =(Countries) xmlSerializer.Deserialize(stringReader);
            Console.WriteLine(countries);
        }
    }
}
