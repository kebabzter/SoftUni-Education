using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class OfficerPrisonerImportModel
    {
        [XmlElement("id")]
        [Required]
        public int PrisonerId { get; set; }
    }
}