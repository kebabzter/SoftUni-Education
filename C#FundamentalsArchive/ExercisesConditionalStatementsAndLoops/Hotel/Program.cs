using System;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            byte nightsCount = byte.Parse(Console.ReadLine());
            double studio = 0;
            double doubleRooms = 0;
            double suite = 0;
            switch (month)
            {
                case "may":
                case "october":
                    studio = 50;
                    doubleRooms = 65;
                    suite = 75;
                    if (nightsCount>7)
                    {
                        studio -= studio * 0.05;
                    }
                    break;
                case "june":
                case "september":
                    studio = 60;
                    doubleRooms = 72;
                    suite = 82;
                    if (nightsCount>14)
                    {
                        doubleRooms -= doubleRooms * 0.1;
                    }
                    break;
                case "july":
                case "august":
                case "december":
                    studio = 68;
                    doubleRooms = 77;
                    suite = 89;
                    if (nightsCount > 14)
                    {
                        suite -= suite * 0.15;
                    }
                    break;
            }
            if ((month== "september" || month=="october")&&nightsCount>7)
            {
                studio *= (nightsCount - 1);
            }
            else
            {
                studio *= nightsCount;
            }
            doubleRooms *= nightsCount;
            suite *= nightsCount;
            Console.WriteLine($"Studio: {studio:f2} lv.");
            Console.WriteLine($"Double: {doubleRooms:f2} lv.");
            Console.WriteLine($"Suite: {suite:f2} lv.");
        }
    }
}
