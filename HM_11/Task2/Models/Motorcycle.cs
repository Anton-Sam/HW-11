using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.Models
{
    [Table("Motorcycles")]
    class Motorcycle : Entity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public int Odometre { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }
        //    var moto = obj as Motorcycle;
        //    return moto.Id.Equals(Id);
        //}

        //public override int GetHashCode()
        //{
        //    return Id.ToString().Length;
        //}

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Model: {Model}, Year: {Year.Year}, Odometre: {Odometre}";
        }
    }
}
