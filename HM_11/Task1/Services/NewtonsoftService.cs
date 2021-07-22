using Newtonsoft.Json;
using System;

namespace Task1.Services
{
    class NewtonsoftService : ISerializeService
    {
        public object DeserializeObject(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string SerializeObject(object obj) => JsonConvert.SerializeObject(obj);
    }
}
