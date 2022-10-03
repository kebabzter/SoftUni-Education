using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();
            switch (type)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(num1,num2));
                    break;
                case "char":
                    char symbol1 = char.Parse(Console.ReadLine());
                    char symbol2 = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(symbol1, symbol2));
                    break;
                case "string":
                    string str1 = Console.ReadLine();
                    string str2 = Console.ReadLine();
                    Console.WriteLine(GetMax(str1, str2));
                    break;
            }
        }
        static int GetMax(int x, int y)
        {
            return Math.Max(x,y);
        }
        static char GetMax(char ch1, char ch2)
        {
            return (char)Math.Max(ch1, ch2);
        }
        static string GetMax(string str1, string str2)
        {
            if (str1.CompareTo(str2)>=0)
            {
                return str1;
            }
            else
            {
                return str2;
            } 
        }
    }
}
