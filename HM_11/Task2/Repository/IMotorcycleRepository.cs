using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Repository
{
    interface IMotorcycleRepository
    {
        Motorcycle GetMotorcycleById(Guid id);
        IEnumerable<Motorcycle> GetMotorcycles();
        void CreateMotorcycle(Motorcycle moto);
        void UpdateMotorcycle(Motorcycle moto);
        void DeleteMotorcycle(Motorcycle moto);
    }
}
