using IntroductionToEFCoreENG.Entites;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCoreENG
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { 
        
        }
        // Table hoga Genre type ka and iska naam hai Genres, genere type jo hai woh humne class define kr rkhi hai jiske andar 2 colums honge name and id

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Genre>().HasKey(g=>g.Identifier);
        }

        public DbSet<Genre> Genres { get; set; }

        
    }
}
