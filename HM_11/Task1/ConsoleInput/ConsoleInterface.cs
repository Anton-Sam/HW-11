using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Enums;
using Task1.Models;
using Task1.Services;
using Task1.Storage;

namespace Task1.ConsoleInput
{
    class ConsoleInterface
    {
        static void ConsoleStartPage(int currentCursorPosition)
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("***********");
            SetConsoleColor(Position.CreateSong, currentCursorPosition);
            Console.WriteLine("Create song");
            SetConsoleColor(Position.GetSong, currentCursorPosition);
            Console.WriteLine("Get song   ");
            SetConsoleColor(Position.SpeedTest, currentCursorPosition);
            Console.WriteLine("Speed test ");
            Console.SetCursorPosition(0, currentCursorPosition);
        }

        static void SetConsoleColor(Position position, int currentCursorPosition)
        {
            if ((int)position == currentCursorPosition)
            {
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
                Console.ResetColor();
        }

        public static void ConsoleManager()
        {
            ConsoleStartPage((int)Position.CreateSong);
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow: MoveVertical((int)MoveDirection.Down); break;
                    case ConsoleKey.UpArrow: MoveVertical((int)MoveDirection.Up); break;
                    case ConsoleKey.Enter: ChooseTask(); break;
                    default: break;
                }
            }
        }

        private static void MoveVertical(int offset)
        {
            if ((Console.CursorTop == (int)Position.CreateSong && offset == -1) || (Console.CursorTop == (int)Position.SpeedTest && offset == 1))
                return;
            else
            {
                Console.CursorTop = Console.CursorTop + offset;
                ConsoleStartPage(Console.CursorTop);
            }
        }

        private static void ChooseTask()
        {
            switch (Console.CursorTop)
            {
                case (int)Position.CreateSong: CreateSong(); break;
                case (int)Position.GetSong: GetSong(); break;
                case (int)Position.SpeedTest: SpeedTest(); break;
            }
        }

        private static void CreateSong()
        {
            ClearConsole();
            var song = new Song()
            {
                Name = InputData.EnterString("Enter song name:", 3),
                Author = InputData.EnterString("Enter author:", 3),
                CreationDate = new DateTime(InputData.EnterIntNumber("Enter album year:", 1900, DateTime.Now.Year), 01, 01),
                Duration = InputData.EnterTimeLength("Enter song duration"),
                Genre = InputData.EnterGenre()
            };
            Database.Songs.Add(song);
            Console.WriteLine("Song succesfully added.");
            Continue();
        }

        private static void ClearConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }

        private static void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            ConsoleStartPage((int)Position.CreateSong);
        }

        private static void GetSong()
        {
            ClearConsole();
            if (Database.Songs.Count > 0)
            {
                Random random = new Random();
                ISongService songService = new SongService();
                ISerializeService serializeService = new NewtonsoftService();
                Console.WriteLine($"Serialized object:\n{serializeService.SerializeObject(songService.GetSongData(Database.Songs[random.Next(0, Database.Songs.Count - 1)]))}");
            }
            else
                Console.WriteLine("There are no any songs in Database");

            Continue();
        }

        private static void SpeedTest()
        {
            ClearConsole();
            if (Database.Songs.Count > 0)
            {
                Random random = new Random();
                ISongService songService = new SongService();
                var serializeCollection = Enumerable.Repeat(songService.GetSongData(Database.Songs[random.Next(0, Database.Songs.Count - 1)]), 100000);
                //Newtonsoft speedtest
                SpeedTestService(new NewtonsoftService(), serializeCollection);
                //Text.Json speedtest
                SpeedTestService(new TextJsonService(), serializeCollection);
            }
            else
                Console.WriteLine("There are no any songs in Database");

            Continue();
        }

        private static void SpeedTestService(ISerializeService serializeService, object serializeObj)
        {
            var sw = new Stopwatch();
            sw.Start();
            serializeService.DeserializeObject(serializeService.SerializeObject(serializeObj));
            sw.Stop();
            Console.WriteLine($"{serializeService.GetType().Name} ellapsed ms: {sw.ElapsedMilliseconds}");
        }
    }
}
