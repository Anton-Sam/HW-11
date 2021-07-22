namespace Task1.Services
{
    interface ISerializeService
    {
        string SerializeObject(object obj);
        object DeserializeObject(string json);
    }
}
