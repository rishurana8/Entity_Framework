using AutoMapper;
using IntroductionToEFCoreENG.Controllers.DTOs;
using IntroductionToEFCoreENG.Entites;

namespace IntroductionToEFCoreENG.Utilities
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles() {
            CreateMap<GenreCreationDTO, Genre>();
        }
    }
}
