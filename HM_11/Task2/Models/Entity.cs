using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var entity = obj as Entity;

            return entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.ToString().Length;
        }
    }
}
