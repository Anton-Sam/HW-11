using System;
using System.Collections.Generic;
using System.Linq;

namespace hm_13.Task2.CustomCollections
{
    class DateTimeQueue : IQueue<DateTime>
    {
        private DateTime[] _queue = new DateTime[1_000];
        private int _position;

        public DateTime Dequeue()
        {           
            var element = Peek();
            for (int i = 1; i < _position; i++)
                _queue[i - 1] = _queue[i];
            _position--;
            return element;            
        }

        public void Enqueue(DateTime element)
        {
            _queue[_position] = element;
            _position++;
        }

        public DateTime Peek()
        {
            if (_position > 0)
                return _queue.First();
            throw new InvalidOperationException("Queue is empty");
        }
    }
}
