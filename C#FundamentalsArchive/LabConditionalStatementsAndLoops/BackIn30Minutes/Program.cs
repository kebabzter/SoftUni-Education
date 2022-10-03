using System;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes= int.Parse(Console.ReadLine());
            minutes += 30;
            if (minutes<=59)
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
            else
            {
                minutes -= 60;
                hours++;
                if (hours<=23)
                {
                    Console.WriteLine($"{hours}:{minutes:d2}");
                }
                else
                {
                    Console.WriteLine($"0:{minutes:d2}");
                }
            }
        }
    }
}
