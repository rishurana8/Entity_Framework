using System.ComponentModel.DataAnnotations;

namespace IntroductionToEFCoreENG.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        //[StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}