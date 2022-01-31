using Motoshop.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Motoshop.Models
{
    public class Moto
    {
        [Guid]
        public string Id { get; set; }
        public int Odometer { get; set; }
        [StringLength(10)]
        public string Model { get; set; }
        public string ImagePreview { get; set; }
        
        [MinYear(MinYear = 2000)]
        public DateTime MadeIn { get; set; }
    }
}
