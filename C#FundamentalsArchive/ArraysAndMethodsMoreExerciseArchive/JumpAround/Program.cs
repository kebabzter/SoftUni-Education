using System;
using System.Linq;

namespace JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();
            long sum =0;
            int index = 0;
            while (true)
            {
                if (index+arr[index]<arr.Length)
                {
                    sum += arr[index];
                    index += arr[index];
                }
                else
                {
                    sum += arr[index];
                    if (index - arr[index] > 0)
                    {
                        index -= arr[index];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
