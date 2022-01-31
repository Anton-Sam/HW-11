using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motoshop.BL
{
    public class StaticCollectionTransportRepository<T> : ITransportRepository<T>
    {
        private static IList<T> _collection = new List<T>();
        
        public void Create(T vehicle)
        {
            if (vehicle == null) return;

            _collection.Add(vehicle);
        }

        public IEnumerable<T> Get()
        {
            return _collection;
        }
    }
}
