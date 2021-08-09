using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Data;
using Task2.Models;

namespace Task2.Repository
{
    class MsSqlEfRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext<T> _context;
        public MsSqlEfRepository()
        {
            _context = new ApplicationDbContext<T>();
        }
        public void Create(T obj)
        {
            _context.Entities.Add(obj);
            _context.SaveChanges();
            Log.Information($"{obj} created");
        }

        public void Delete(T obj)
        {
            _context.Entities.Remove(obj);
            _context.SaveChanges();
            Log.Information($"{obj} deleted");
        }

        public T GetById(Guid id)
        {
            Type type = typeof(T);
            var obj = _context.Entities.FirstOrDefault(o => o.Id.Equals(id));
            Log.Information($"{obj} got by id");
            return obj;
        }

        public IEnumerable<T> GetObjects()
        {
            Log.Information($"All motorcycles got");
            return _context.Entities;
        }

        public void Update(T obj)
        {
            _context.Entities.Update(obj);
            _context.SaveChanges();
            Log.Information($"{obj} updated");
        }
    }
}
