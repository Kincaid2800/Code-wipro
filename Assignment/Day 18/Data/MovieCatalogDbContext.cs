using Microsoft.EntityFrameworkCore;
using MovieCatalogApi.Models;

namespace MovieCatalogApi.Data
{
    public class MovieCatalogDbContext : DbContext
    {
        public MovieCatalogDbContext(DbContextOptions<MovieCatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                .WithOne(m => m.Director)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
