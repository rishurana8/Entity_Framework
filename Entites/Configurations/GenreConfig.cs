using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroductionToEFCoreENG.Entites.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //modelBuilder.Entity<Genre>().HasKey(g => g.Identifier);
            //modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(150);
        }
    }
}
