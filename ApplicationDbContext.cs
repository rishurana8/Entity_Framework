using IntroductionToEFCoreENG.Entites;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCoreENG
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // Table hoga Genre type ka and iska naam hai Genres, genere type jo hai woh humne class define kr rkhi hai jiske andar 2 colums honge name and id
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Genre>().HasKey(g => g.Identifier);
            //modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(150);

            //modelBuilder.Entity<Actor>().Property(a => a.Name).HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(a => a.DateOfBirth).HasColumnType("date");

            // example: 123.45 , 5 digits and 2 are decimals
            modelBuilder.Entity<Actor>().Property(a => a.Fortune).HasPrecision(18, 2);

            //modelBuilder.Entity<Movie>().Property(m => m.Title).HasMaxLength(150);
            modelBuilder.Entity<Movie>().Property(a => a.ReleaseDate).HasColumnType("date");

            modelBuilder.Entity<Comment>().Property(p => p.Content).HasMaxLength(500);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
