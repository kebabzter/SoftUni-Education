namespace Git.Data
{
    using Git.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class GitDbContext : DbContext
    {
        public DbSet<Commit> Commits { get; set; }

        public DbSet<Repository> Repositories { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (@"Server=PC-GABRIEL\SQLEXPRESS;Database=Git;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commit>()
                .HasKey(k => new { k.CreatorId, k.RepositoryId });
        }
    }
}