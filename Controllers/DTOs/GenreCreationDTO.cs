using System.ComponentModel.DataAnnotations;

namespace IntroductionToEFCoreENG.Controllers.DTOs
{
    public class GenreCreationDTO
    {
        [StringLength(maximumLength:150)]
        public string Name { get; set; } = null!;

    }
}
