using System;
using System.Collections.Generic;
using System.Linq;

namespace hm_13.Task2.CustomCollections
{
    class ObjectQueue : IQueue<object>
    {
        private readonly IList<object> _queue = new List<object>();

        public object Dequeue()
        {
            try
            {
                var element = Peek();
                _queue.RemoveAt(0);
                return element;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public void Enqueue(object element)
        {
            _queue.Add(element);
        }

        public object Peek()
        {
            if (_queue.Any())
                return _queue.First();
            throw new InvalidOperationException("Queue is empty");
        }
    }
}
