using System.ComponentModel.DataAnnotations;

namespace IntroductionToEFCoreENG.DTOs
{
    public class ActorCreationDTO
    {
        [StringLength(150)]
        public string Name { get; set; } = null!;
        public decimal Fortune { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}