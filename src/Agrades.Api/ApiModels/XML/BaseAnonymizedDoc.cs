using System.Xml.Serialization;

namespace Agrades.Api.ApiModels.XML
{
    public class BaseAnonymizedDoc
    {
        [XmlElement(ElementName = "Vygen")]
        public string GeneratedBy { get; set; }
        [XmlElement(ElementName = "autor")]
        public string Author { get; set; }
        [XmlElement(ElementName = "telefon")]
        public string PhoneNumber { get; set; }
        [XmlElement(ElementName = "e-mail")]
        public string Email { get; set; }
        [XmlElement(ElementName = "soubor")]
        public string DocumentName { get; set; }
        [XmlElement(ElementName = "vytvoreno")]
        public string CreatedAt { get; set; }
        [XmlArray]
        public Sentence[] Sentences { get; set; }

    }
}
