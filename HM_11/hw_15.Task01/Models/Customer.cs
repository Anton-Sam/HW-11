using System;
using System.ComponentModel.DataAnnotations;

namespace hw_15.Task01.Models
{
    class Customer : Entity
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(18, 100)]
        public int Age { get; set; }
    }
}
