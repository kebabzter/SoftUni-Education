using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Actor")]
    public class ActorXmlExportDto
    {

        [XmlAttribute("FullName")]
        public string FullName { get; set; }


        [XmlAttribute("MainCharacter")]
        public string MainCharacter { get; set; }
    }
}