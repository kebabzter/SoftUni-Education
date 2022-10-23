using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastsXmlImportDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName { get; set; }

        [Required]
        public bool IsMainCharacter { get; set; }

        [Required]
        [RegularExpression(@"\+44-[0-9]{2}-[0-9]{3}-[0-9]{4}")]
        public string PhoneNumber { get; set; }

        public int PlayId { get; set; }
    }

  //  <Cast>
  //  <FullName>Van Tyson</FullName>
  //  <IsMainCharacter>false</IsMainCharacter>
  //  <PhoneNumber>+44-35-745-2774</PhoneNumber>
  //  <PlayId>26</PlayId>
  //</Cast>

}
