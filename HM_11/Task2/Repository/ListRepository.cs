using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Repository
{
    class ListRepository<T> : IRepository<T> where T : Entity
    {
        private List<T> _objects { get; set; } = new List<T>();
        public void Create(T obj)
        {                  
            if (!_objects.Contains(obj))
            {
                _objects.Add(obj);
                Log.Information($"{obj} created");
            }
        }

        public void Delete(T obj)
        {
            _objects.Remove(obj);
            Log.Information($"{obj} deleted");
        }

        public T GetById(Guid id)
        {
            var obj = _objects.FirstOrDefault(o => o.Id.Equals(id));
            Log.Information($"{obj} got by id");
            return obj;                  
        }

        public IEnumerable<T> GetObjects()
        {
            Log.Information($"All motorcycles got");
            return _objects;
        }

        public void Update(T obj)
        {
            var index = _objects.FindIndex(o => o.Equals(obj));
            if (index < 0)
                Create(obj);
            else
                _objects[index] = obj;
            Log.Information($"{obj} updated");
        }
    }
}
