using System;
using System.ComponentModel.DataAnnotations;

namespace hw_15.Task01.Models
{
    class Motorcycle
    {
        [Required, StringLength(50, MinimumLength = 10)]
        public string VIN { get; set; }
        [Required, StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }
        [Range(0, 100)]
        public int Odometer { get; set; }
    }
}
