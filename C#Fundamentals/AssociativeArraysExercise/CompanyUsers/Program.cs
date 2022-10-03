using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> company = new SortedDictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] info = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                string id = info[1];
                if (!company.ContainsKey(name))
                {
                    company.Add(name, new List<string>());
                }
                company[name].Add(id);
            }

            foreach (var item in company)
            {
                Console.WriteLine(item.Key);
                List<string> uniqueId = item.Value.Distinct().ToList();
                foreach (var id in uniqueId)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
