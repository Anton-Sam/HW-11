using System;
using System.Collections.Generic;
using System.Linq;

namespace hm_13.Task2.CustomCollections
{
    class GenericQueue<T> : IQueue<T> where T : class
    {
        private readonly IList<T> _queue = new List<T>();

        public T Dequeue()
        {
            var element = Peek();
            _queue.RemoveAt(0);
            return element;
        }

        public void Enqueue(T obj)
        {
            _queue.Add(obj);
        }

        public T Peek()
        {
            if (_queue.Any())
                return _queue.First();
            throw new InvalidOperationException("Queue is empty");
        }
    }
}
