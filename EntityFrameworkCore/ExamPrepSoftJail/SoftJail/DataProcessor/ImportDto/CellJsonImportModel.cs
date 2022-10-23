using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.Dto
{
    public class CellJsonImportModel
    {
        [Required]
        [Range(1,1000)]
        public int CellNumber { get; set; }

        [Required]
        public bool HasWindow { get; set; }

    }
}
