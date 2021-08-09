namespace hm_13.Task2.CustomCollections
{
    interface IQueue<T>
    {
        T Dequeue();
        void Enqueue(T obj);
        T Peek();
    }
}
