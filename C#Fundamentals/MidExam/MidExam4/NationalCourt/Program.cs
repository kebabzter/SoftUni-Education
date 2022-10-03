using System;

namespace NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int allEmployees = 0;
            for (int i = 1; i <= 3; i++)
            {
                int people = int.Parse(Console.ReadLine());
                allEmployees += people;
            }
            int peopleCount = int.Parse(Console.ReadLine());
            if (peopleCount > 0)
            {
                int time = 1;
                int count = 0;
                for (int i = allEmployees; i < peopleCount; i += allEmployees)
                {
                    count++;
                    if (count % 3 == 0)
                    {
                        time += 2;
                        count = 0;
                    }
                    else
                    {
                        time++;
                    }
                }
                Console.WriteLine($"Time needed: {time}h.");
            }
            else
            {
                Console.WriteLine($"Time needed: 0h.");
            }
        }
    }
}
