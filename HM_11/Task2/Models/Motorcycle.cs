using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    class Motorcycle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public int Odometre { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var moto = obj as Motorcycle;
            return moto.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.ToString().Length;
        }
    }
}
