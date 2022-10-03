using System;
using System.Linq;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int maxNum = 0;
            int maxCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentCount=arr.Where(x=>x==arr[i]).Count();
                if (currentCount>maxCount)
                {
                    maxCount = currentCount;
                    maxNum = arr[i];
                }
            }
            Console.WriteLine(maxNum);
        }
    }
}
