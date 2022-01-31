using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_15.Task01.Models
{
    abstract class Entity
    {
        public Guid Id { get; } = Guid.NewGuid();      
    }
}
