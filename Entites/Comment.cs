﻿namespace IntroductionToEFCoreENG.Entites
{
    public class Comment
    {
        public int Id { get; set; }

         public string Content { get; set; }

        public bool Recommend {  get; set; }

        public int MovieId {  get; set; }

        // foregin key jo movie se refernce legi 
        public Movie Movie { get; set; }

    }
}
