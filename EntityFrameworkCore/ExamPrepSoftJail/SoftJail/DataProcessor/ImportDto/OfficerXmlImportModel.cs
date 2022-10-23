using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerXmlImportModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Required]
        [Range(0.0, 79228162514264337593543950335.0)]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public OfficerPrisonerImportModel[] Prisoners { get; set; }
    }

  //  <Officers>
  //<Officer>
  //  <Name>Minerva Kitchingman</Name>
  //  <Money>2582</Money>
  //  <Position>Invalid</Position>
  //  <Weapon>ChainRifle</Weapon>
  //  <DepartmentId>2</DepartmentId>
  //  <Prisoners>
  //    <Prisoner id = "15" />
  //  </ Prisoners >
  //</ Officer >

}
