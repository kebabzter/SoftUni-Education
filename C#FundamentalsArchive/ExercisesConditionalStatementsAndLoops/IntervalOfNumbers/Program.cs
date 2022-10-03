using System;

namespace IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            byte start = byte.Parse(Console.ReadLine());
            byte end = byte.Parse(Console.ReadLine());
            for (byte i = Math.Min(start,end); i <=Math.Max(start,end); i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
