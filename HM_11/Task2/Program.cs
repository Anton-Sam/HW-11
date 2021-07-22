using System;
using Task2.Controllers;
using Task2.Models;
using Task2.Repository;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            IMotorcycleRepository repository = new MsSqlAdoMotorcycleRepository();
            var moto= new Motorcycle
            {
                Id = Guid.NewGuid(),
                Name = "Honda CBR-600",
                Model = "CBR-600",
                Year = new DateTime(2000, 1, 1),
                Odometre = 56000
            };
            repository.CreateMotorcycle(moto);
            
            var res=repository.GetMotorcycles();

            var res1=repository.GetMotorcycleById(moto.Id);

            moto.Name = "Yamaha";
            repository.UpdateMotorcycle(moto);
            var res4 = repository.GetMotorcycleById(moto.Id);
            repository.DeleteMotorcycle(moto);

            var res2 = repository.GetMotorcycles();
        }
    }
}
