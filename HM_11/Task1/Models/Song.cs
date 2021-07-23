using System;
using Task1.Enums;

namespace Task1.Models
{    
    class Song
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public string Author { get; set; }
        public DateTime CreationDate { get; set; }
        public Genre Genre { get; set; }

        //public Song(string name, int duration, string author, DateTime creationDate, Genre genre) =>
        //    (Name, Duration, Author, CreationDate, Genre) = (name, duration, author, creationDate, genre);

        //public Song(string name, int duration, string author, DateTime creationDate, int genre) :
        //    this(name, duration, author, creationDate, Enum.IsDefined(typeof(Genre), genre) ? (Genre)genre : default(Genre))
        //{ }
    }
}
