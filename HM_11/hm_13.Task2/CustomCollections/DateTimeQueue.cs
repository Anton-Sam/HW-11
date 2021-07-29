using System;
using System.Collections.Generic;
using System.Linq;

namespace hm_13.Task2.CustomCollections
{
    class DateTimeQueue : IQueue<DateTime>
    {
        private readonly IList<DateTime> _queue = new List<DateTime>();

        public DateTime Dequeue()
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

        public void Enqueue(DateTime element)
        {
            _queue.Add(element);
        }

        public DateTime Peek()
        {
            if (_queue.Any())
                return _queue.First();
            throw new InvalidOperationException("Queue is empty");
        }
    }
}
