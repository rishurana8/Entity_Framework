using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCoreENG
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { 
        
        }
        public DbSet<Genre> Genres { get; set; }

        
    }
}
