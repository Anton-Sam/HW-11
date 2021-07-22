using System;

namespace Task1.Models
{
    enum Genre
    {
        Other,
        Classic,
        Rock,
        Jazz,
        Pop,
        HipHop
    }
    class Song
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public Genre Genre { get; set; }

        public Song(string name, int duration, string author, DateTime creationDate, Genre genre) =>
            (Name, Duration, Author, CreationDate, Genre) = (name, duration, author, creationDate, genre);

        public Song(string name, int duration, string author, DateTime creationDate, int genre) :
            this(name, duration, author, creationDate, Enum.IsDefined(typeof(Genre), genre) ? (Genre)genre : default(Genre))
        { }
    }
}
