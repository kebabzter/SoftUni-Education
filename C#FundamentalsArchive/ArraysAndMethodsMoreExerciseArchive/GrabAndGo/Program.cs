using System;
using System.Linq;

namespace GrabAndGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            int index = 0;
            bool flag = false;
            for (int i = arr.Length-1; i >=0; i--)
            {
                if (arr[i]==n)
                {
                    index = i;
                    flag = true;
                    break;
                }
            }
            long sum = 0;
            if (flag)
            {
                for (int i = 0; i < index; i++)
                {
                    sum += arr[i];
                }
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
