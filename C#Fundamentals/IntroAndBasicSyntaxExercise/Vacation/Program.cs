using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine().ToLower();
            string day = Console.ReadLine().ToLower();
            double price = 0;
            switch (typeOfGroup)
            {
                case "students":
                    switch (day)
                    {
                        case "friday":
                            price = 8.45 * peopleCount;
                            break;
                        case "saturday":
                            price = 9.80 * peopleCount;
                            break;
                        case "sunday":
                            price = 10.46 * peopleCount;
                            break;
                    }
                    if (peopleCount >= 30)
                    {
                        price -= price * 0.15;
                    }
                    break;
                case "business":
                    if (peopleCount >= 100)
                    {
                        peopleCount -= 10;
                    }
                    switch (day)
                    {
                        case "friday":
                            price = 10.90 * peopleCount;
                            break;
                        case "saturday":
                            price = 15.60 * peopleCount;
                            break;
                        case "sunday":
                            price = 16.0 * peopleCount;
                            break;
                    }
                    break;
                case "regular":
                    switch (day)
                    {
                        case "friday":
                            price = 15.0 * peopleCount;
                            break;
                        case "saturday":
                            price = 20.0 * peopleCount;
                            break;
                        case "sunday":
                            price = 22.50 * peopleCount;
                            break;
                    }
                    if (peopleCount >= 10 && peopleCount <= 20)
                    {
                        price -= price * 0.05;
                    }
                    break;
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
