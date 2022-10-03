using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeupleGeneric
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = first[0] + " " + first[1];
            string address = first[2];
            List<string> townList = first.ToList().Skip(3).ToList();
            string town = string.Join(" ", townList);
            Threeuple<string, string, string> tupleOne = new Threeuple<string, string, string>(name, address, town);

            string[] two = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string nameTwo = two[0];
            int liters = int.Parse(two[1]);
            string drink = two[2];
            bool flag = false;
            if (drink == "drunk")
            {
                flag = true;
            }
            Threeuple<string, int, bool> tupleTwo = new Threeuple<string, int, bool>(nameTwo, liters, flag);

            string[] three = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string threeName = three[0];
            double threeDouble = double.Parse(three[1]);
            string bankName = three[2];
            Threeuple<string, double, string> tupleThree = new Threeuple<string, double, string>(threeName, threeDouble, bankName);

            Console.WriteLine(tupleOne);
            Console.WriteLine(tupleTwo);
            Console.WriteLine(tupleThree);
        }
    }
}
