namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Player
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(PlayerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Position { get; set; }

        [Range(0,10)]
        public byte Speed { get; set; }

        [Range(0, 10)]
        public byte Endurance { get; set; }

        [Required]
        [MaxLength(PlayerDescriptionMaxLength)]
        public string Description { get; set; }

        public IEnumerable<UserPlayer> UserPlayers { get; init; } = new List<UserPlayer>();
    }
}
