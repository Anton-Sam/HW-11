using Serilog;
using System;
using Task2.Models;
using Task2.Repository;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramStart();
            TestRepository(new ListRepository<Motorcycle>());
            TestRepository(new MsSqlAdoMotorcycleRepository());
            TestRepository(new MsSqlEfRepository<Motorcycle>());
        }

        private static void TestRepository(IRepository<Motorcycle> repository)
        {
            var moto = new Motorcycle
            {
                Name = "Honda CBR-600",
                Model = "CBR-600",
                Year = new DateTime(2000, 1, 1),
                Odometre = 56000
            };
            repository.Create(moto);

            var motos = repository.GetObjects();

            var moto2 = repository.GetById(moto.Id);

            moto.Name = "Yamaha";
            repository.Update(moto);
            
            var moto3 = repository.GetById(moto.Id);
            repository.Delete(moto3);

            var motos1 = repository.GetObjects();
        }

        private static void ProgramStart()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("../../../Logs/log.txt", rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            var type = typeof(Program);

            Log.Information($"Program: {type.Assembly.FullName}, namespace: {type.Namespace}");
        }
    }
}
