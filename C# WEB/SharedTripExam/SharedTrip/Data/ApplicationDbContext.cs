namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Data.Models;
    using static DatabaseConfiguration;
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; init; }

        public DbSet<Trip> Trips { get; init; }

        public DbSet<UserTrip> UserTrips { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
                .HasKey(t => new {t.UserId, t.TripId});
        }
    }
}
