using System;

namespace CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int num;
            int count = 0;
            while (int.TryParse(input, out num))
            {
                input = Console.ReadLine();
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
