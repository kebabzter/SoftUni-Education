﻿using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class TicketJsonImportDto
    {
        [Required]
        [Range(1.00,100.00)]
        public decimal Price { get; set; }

        [Range(1,10)]
        public sbyte RowNumber { get; set; }
        public int PlayId { get; set; }
    }


}
