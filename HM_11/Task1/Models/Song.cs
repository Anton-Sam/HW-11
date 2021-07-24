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
    }
}
