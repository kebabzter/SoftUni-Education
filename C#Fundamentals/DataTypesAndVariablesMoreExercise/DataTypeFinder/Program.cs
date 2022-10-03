using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = String.Empty;
            while (input != "END")
            {
                if (int.TryParse(input, out int integer))
                {
                    result = "integer";
                }
                else if (float.TryParse(input, out float floatingPoint))
                {
                    result = "floating point";
                }
                else if (char.TryParse(input, out char characters))
                {
                    result = "character";
                }
                else if (bool.TryParse(input, out bool boolean))
                {
                    result = "boolean";
                }
                else
                {
                    result = "string";
                }
                Console.WriteLine($"{input} is {result} type");
                input = Console.ReadLine();
            }
        }
    }
}
