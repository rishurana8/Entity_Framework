using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroductionToEFCoreENG.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //modelBuilder.Entity<Genre>().HasKey(g => g.Identifier);
            //modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(150);

            var scienceFiction = new Genre() { Id = 5, Name = "Science Fiction" };
            var animation = new Genre() { Id = 6, Name = "Animation" };
            builder.HasData(scienceFiction, animation);

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}