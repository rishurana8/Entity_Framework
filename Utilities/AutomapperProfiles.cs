using AutoMapper;
using IntroductionToEFCoreENG.Controllers.DTOs;
using IntroductionToEFCoreENG.Entites;

namespace IntroductionToEFCoreENG.Utilities
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles() {
            CreateMap<GenreCreationDTO, Genre>();
            CreateMap<ActorCreationDTO, Actor>();
            CreateMap<CommentCreationDTO, Comment>();
            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(ent => ent.Genres,
                dto => dto.MapFrom(field => field.Genres.Select(id => new Genre() { Id = id })));

            CreateMap<MovieActorCreationDTO, MovieActor>();
        }
    }
}
