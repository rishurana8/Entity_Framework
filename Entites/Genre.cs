using System.ComponentModel.DataAnnotations;

namespace IntroductionToEFCoreENG.Entites
{
    //  It is just a simple class and in order to make it entity we have to set property of dbset gener
    public class Genre
    { 
        [Key]  // This will tell that it is a primary key
        public int Identifier { get; set; }

        [StringLength(maximumLength:150)]
        public string Name { get; set; }=null!;
    }
}
