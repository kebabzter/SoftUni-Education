namespace FootballManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IEnumerable<UserPlayer> UserPlayers { get; init;} = new List<UserPlayer>();
    }
}
