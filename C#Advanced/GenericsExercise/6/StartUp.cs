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
            List<double> list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }
            Box<double> box = new Box<double>(list);
            double compare =double.Parse(Console.ReadLine());
            int count = box.CountGreaterElements(list, compare);
            Console.WriteLine(count);
        }
    }
}
