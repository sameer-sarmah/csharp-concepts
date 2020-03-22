using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace csharp_concepts.io.xml.model
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("countries")]
    public class Countries
    {
        [System.Xml.Serialization.XmlElement("country")]
        public List<Country> countries { get; set; }
    }
}
