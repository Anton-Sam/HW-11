using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Enums;

namespace Task1.ConsoleInput
{
    class InputData
    {
        public static string EnterString(string request, int minimumLength)
        {
            Console.Write(request);
            string inputString = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(inputString) && inputString.Length >= minimumLength)
                return inputString;

            return EnterString($"Input string length must be > {minimumLength.ToString()} symbols. Reenter:", minimumLength);
        }

        public static int EnterIntNumber(string request, int lowerLimit, int upperLimit)
        {
            Console.Write(request + $" within [{lowerLimit};{upperLimit}]: ");
            if (int.TryParse(Console.ReadLine(), out int number))
                if (number >= lowerLimit && number <= upperLimit)
                    return number;

            return EnterIntNumber($"Entered value is out of range. Reenter", lowerLimit, upperLimit);
        }

        public static TimeSpan EnterTimeLength(string request)
        {
            Console.Write($"{request} in format 'mm:ss'): ");
            Regex reg = new Regex(@"\d{2}:\d{2}:\d{2}");
            string intputString = $"00:{Console.ReadLine()}";
            if (reg.IsMatch(intputString))
                if (TimeSpan.TryParseExact(intputString, "hh\\:mm\\:ss", CultureInfo.CurrentCulture, out TimeSpan timeLength))
                    return timeLength;

            return EnterTimeLength($"Entered value is not in a correct format. Reenter");
        }

        public static Genre EnterGenre()
        {
            Console.Write($"Possible genres: {BuildGenreList()}\nEnter song genre (name or index): ");
            string inputString = Console.ReadLine();
            switch (inputString)
            {
                case string index when int.TryParse(inputString, out _):
                    return Enum.IsDefined(typeof(Genre), int.Parse(inputString)) ? (Genre)int.Parse(inputString) : default(Genre);
                default: return Enum.IsDefined(typeof(Genre), inputString) ? (Genre)Enum.Parse(typeof(Genre), inputString) : default(Genre);
            }
        }

        private static string BuildGenreList()
        {
            StringBuilder sb = new StringBuilder();
            var genres = Enum.GetValues(typeof(Genre));
            foreach (var item in genres)
                sb.Append($" {item} - {(int)item},");
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}
