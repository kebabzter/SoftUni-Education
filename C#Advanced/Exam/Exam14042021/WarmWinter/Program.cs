using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondLine = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Stack<int> hats = new Stack<int>(firstLine);
            Queue<int> scarfs = new Queue<int>(secondLine);
            int sum = 0;
            List<int> sets = new List<int>();
            while (hats.Count>0&&scarfs.Count>0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (scarf == hat)
                {
                    scarfs.Dequeue();
                    hat++;
                    hats.Pop();
                    hats.Push(hat);
                }
                else if (hat>scarf)
                {
                    sum = hat + scarf;
                    hats.Pop();
                    scarfs.Dequeue();
                    sets.Add(sum);
                }
                else// (scarf>hat)
                {
                    hats.Pop();
                    continue;
                }
                
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
