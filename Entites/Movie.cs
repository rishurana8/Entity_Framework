﻿namespace IntroductionToEFCoreENG.Entites
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool InTheaters {  get; set; }

        public DateTime ReleaseDate{ get; set; }


    }
}
