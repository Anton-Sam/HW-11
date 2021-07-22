using System;
using System.Diagnostics;
using System.Linq;
using Task1.Models;
using Task1.Services;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            ISongService songService = new SongService();
            var song = new Song("New Divide", 3, "Linkin Park", new DateTime(2009, 05, 18), Genre.Rock);
            Console.WriteLine($"Serialized object:\n{songService.GetSongData(song)}");

            var serializeCollection = Enumerable.Repeat(songService.GetSongData(song), 100000);
            //Newtonsoft speedtest
            SpeedTest(new NewtonsoftService(), serializeCollection);
            //Text.Json speedtest
            SpeedTest(new TextJsonService(), serializeCollection);
        }

        private static void SpeedTest(ISerializeService serializeService, object serializeObj)
        {
            var sw = new Stopwatch();
            sw.Start();
            serializeService.DeserializeObject(serializeService.SerializeObject(serializeObj));
            sw.Stop();
            Console.WriteLine($"Ellapsed ms: {sw.ElapsedMilliseconds}");
        }
    }
}
