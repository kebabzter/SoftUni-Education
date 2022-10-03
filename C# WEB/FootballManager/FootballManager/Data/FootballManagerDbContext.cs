namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {
        public DbSet<Player> Players { get; init; }

        public DbSet<User> Users { get; init; }

        public DbSet<UserPlayer> UserPlayers { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=PC-GABRIEL\SQLEXPRESS;Database=FootballManager;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayer>()
                .HasKey(up => new { up.UserId, up.PlayerId });
        }
    }
}
