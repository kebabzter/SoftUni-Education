using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = $"{info[0]} {info[1]}";
            string city = $"{info[2]}";

            string[] infoTwo = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = infoTwo[0];
            int liters = int.Parse(infoTwo[1]);

            string[] infoThree = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int numInt = int.Parse(infoThree[0]);
            double numDouble = double.Parse(infoThree[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName,city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name,liters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(numInt,numDouble);
            
            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
