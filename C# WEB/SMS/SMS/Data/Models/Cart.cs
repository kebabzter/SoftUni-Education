using SMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    using static DataConstants;

    public class Cart
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
