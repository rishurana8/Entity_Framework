namespace IntroductionToEFCoreENG.Entites
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool InTheaters {  get; set; }

        public DateTime ReleaseDate{ get; set; }

        // As movie ke andar kafi saare comments honge so humne hashset nahi rkhna 
        // so here we have added one to many relationship between movie and comments
        public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();

        public HashSet<Genre> Genres { get; set; } = new HashSet<Genre>();


    }
}
