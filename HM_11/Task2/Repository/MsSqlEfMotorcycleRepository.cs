using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;
using Task2.Storage;

namespace Task2.Repository
{
    class MsSqlEfRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ObjectContext<T> _context;
        public MsSqlEfRepository()
        {
            _context = new ObjectContext<T>();
        }
        public void Create(T obj)
        {            
            _context.Objects.Add(obj);
            _context.SaveChanges();
            Log.Information($"{obj} created");
        }

        public void Delete(T obj)
        {
            _context.Objects.Remove(obj);
            _context.SaveChanges();
            Log.Information($"{obj} deleted");
        }

        public T GetById(Guid id)
        {
            Type type = typeof(T);
            var obj = _context.Objects.FirstOrDefault(o => o.Id.Equals(id));
            Log.Information($"{obj} got by id");
            return obj;
        }

        public IEnumerable<T> GetObjects()
        {
            Log.Information($"All motorcycles got");
            return _context.Objects;
        }

        public void Update(T obj)
        {
            _context.Objects.Update(obj);
            _context.SaveChanges();
            Log.Information($"{obj} updated");
        }
    }
}
