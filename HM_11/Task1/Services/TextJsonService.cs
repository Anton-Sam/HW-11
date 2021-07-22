using System;
using System.Text.Json;

namespace Task1.Services
{
    class TextJsonService : ISerializeService
    {
        public object DeserializeObject(string json)
        {
            try
            {
                return JsonSerializer.Deserialize(json, typeof(object));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string SerializeObject(object obj) => JsonSerializer.Serialize(obj);
    }
}
