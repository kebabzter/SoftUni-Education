using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
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
                string command = info[0];
                switch (command)
                {
                    case "Citizen":
                        string name = info[1];
                        int age = int.Parse(info[2]);
                        string id = info[3];
                        string birthdate = info[4];
                        data.Add(new Citizen(name, age, id,birthdate));
                        break;
                    case "Pet":
                        string nameP = info[1];
                        string birthdateP = info[2];
                        data.Add(new Pet(nameP,birthdateP));
                        break;
                }
                
            }

            string filter = Console.ReadLine();
            List<IIdentifiable> result = data.Where(x => x.Birthdate.EndsWith(filter)).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
