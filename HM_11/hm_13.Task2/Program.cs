using hm_13.Task2.CustomCollections;
using System;
using System.Collections.Generic;

namespace hm_13.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQueue(new DateTimeQueue(), DateTime.Now, DateTime.Now.AddDays(-1),DateTime.Now.AddDays(-3));
            TestQueue(new ObjectQueue(), 1, "hello");
            TestQueue(new GenericQueue<string>(), "str1", "str2","str3");
            //TestQueue(new GenericQueue<int>(), "1", "2"); - error because try to use struct
        }

        private static void TestQueue<T>(IQueue<T> queue, params T[] values)
        {
            if (queue is null)
            {
                Console.WriteLine("Queue is null");
                return;
            }

            if (values is null)
            {
                Console.WriteLine("Test values array is null");
                return;
            }

            Console.WriteLine("Test values:");
            Array.ForEach(values, val =>
             {
                 Console.WriteLine(val);
                 queue.Enqueue(val);
             });

            try
            {
                var el = queue.Peek();
                Console.WriteLine($"Peek: {el}");
                el = queue.Dequeue();
                Console.WriteLine($"Dequeue: {el}");
                el = queue.Dequeue();
                Console.WriteLine($"Dequeue: {el}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
