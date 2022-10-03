using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string command=Console.ReadLine();
            switch (command)
            {
                case "int":
                    int numberI = int.Parse(Console.ReadLine());
                    NumberInt(numberI);
                    break;
                case "real":
                    double numberD = double.Parse(Console.ReadLine());
                    NumberReal(numberD);
                    break;
                case "string":
                    string str = Console.ReadLine();
                    StringStr(str);
                    break;
            }
        }

        static void NumberInt(int num)
        {
            Console.WriteLine(num*2);
        }

        static void NumberReal(double num)
        {
            double result = num * 1.5;
            Console.WriteLine($"{result:f2}");
        }

        static void StringStr(string str)
        {
            Console.WriteLine($"${str}$");
        }
    }
}
