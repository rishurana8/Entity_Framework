using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroductionToEFCoreENG.Entites.Configurations
{
    public class Actorconfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //modelBuilder.Entity<Actor>().Property(a => a.Name).HasMaxLength(150);
            builder.Property(a => a.DateOfBirth).HasColumnType("date");

            // example: 123.45 , 5 digits and 2 are decimals
            builder.Property(a => a.Fortune).HasPrecision(18, 2);
        }
    }
}
