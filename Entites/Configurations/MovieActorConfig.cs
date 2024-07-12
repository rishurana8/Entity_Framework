using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroductionToEFCoreENG.Entites.Configurations
{
    public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            // so now we will have a composite key which will be composed of actorid and movieid
            builder.HasKey(ma=> new {ma.ActorId,ma.MovieId});
        }
    }
}
