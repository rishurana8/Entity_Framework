using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroductionToEFCoreENG.Entities.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //modelBuilder.Entity<Movie>().Property(m => m.Title).HasMaxLength(150);
            builder.Property(a => a.ReleaseDate).HasColumnType("date");
        }
    }
}