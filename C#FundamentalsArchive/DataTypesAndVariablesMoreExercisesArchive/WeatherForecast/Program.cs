using System;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            if (sbyte.TryParse(num, out sbyte sbyteTime)|| byte.TryParse(num, out byte byteTime))
            {
                Console.WriteLine("Sunny");
            }
            else if (int.TryParse(num, out int intTime))
            {
                Console.WriteLine("Cloudy");
            }
            else if (long.TryParse(num, out long longTime))
            {
                Console.WriteLine("Windy");
            }
            else if (float.TryParse(num, out float floatTime))
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}
