using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace IntroductionToEFCoreENG.Entities.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            //modelBuilder.Entity<Actor>().Property(a => a.Name).HasMaxLength(150);
            builder.Property(a => a.DateOfBirth).HasColumnType("date");
            builder.Property(a => a.Fortune).HasPrecision(18, 2);
        }
    }
}