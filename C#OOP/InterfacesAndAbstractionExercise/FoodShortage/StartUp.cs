using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> data = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 3)
                {
                    string name = info[0];
                    int age =int.Parse(info[1]);
                    string group = info[2];
                    data.Add(new Rebel(name,age,group));
                }
                else
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    string birthdate = info[3];
                    data.Add(new Citizen(name, age, id,birthdate));
                }
            }
           
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                if (data.Any(x => x.Name == input))
                {
                    data.Where(x => x.Name == input).First().BuyFood();
                }
            }

            Console.WriteLine(data.Sum(x => x.Food));
        }
    }
}
