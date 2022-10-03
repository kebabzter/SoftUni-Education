using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }
            Box<string> box = new Box<string>(list);
            string compare = Console.ReadLine();
            int count = box.CountGreaterElements(list, compare);
            Console.WriteLine(count);
        }
    }
}
