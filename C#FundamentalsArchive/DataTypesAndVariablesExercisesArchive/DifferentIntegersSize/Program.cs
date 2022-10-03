using System;

namespace DifferentIntegersSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            if (long.TryParse(str, out long result))
            {
                Console.WriteLine($"{str} can fit in:");
                if (sbyte.TryParse(str, out sbyte resultsb))
                {
                    Console.WriteLine("* sbyte");
                }
                if (byte.TryParse(str, out byte resultb))
                {
                    Console.WriteLine("* byte");
                }
                if (short.TryParse(str, out short results))
                {
                    Console.WriteLine("* short");
                }
                if (ushort.TryParse(str, out ushort resultus))
                {
                    Console.WriteLine("* ushort");
                }
                if (int.TryParse(str, out int resulti))
                {
                    Console.WriteLine("* int");
                }
                if (uint.TryParse(str, out uint resultui))
                {
                    Console.WriteLine("* uint");
                }
                Console.WriteLine("* long");
            }
            else
            {
                Console.WriteLine($"{str} can't fit in any type");
            }
        }
    }
}
