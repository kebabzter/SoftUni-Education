using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> data = new List<IIdentifiable>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 2)
                {
                    string model = info[0];
                    string id = info[1];
                    data.Add(new Robot(model, id));
                }
                else
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    data.Add(new Citizen(name, age, id));
                }
            }

            string filter = Console.ReadLine();
            List<IIdentifiable> result = data.Where(x => x.Id.EndsWith(filter)).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
