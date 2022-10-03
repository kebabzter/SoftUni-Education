using System;

namespace BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            bool input = bool.Parse(Console.ReadLine());
            if (input)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
