using System;
using System.Linq;

namespace MaxSequenceOfIncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int maxCount = 0;
            string maxNum = String.Empty;
            string currentNum = String.Empty;
            int currentCount = 1;
            for (int i = 0; i < arr.Length-1; i++)
            {
               
                if (arr[i]<arr[i+1])
                {
                    currentCount++;
                    currentNum+= arr[i] + " ";
                    if (currentCount > maxCount)
                    {

                        maxCount = currentCount;
                        maxNum = currentNum +arr[i+1];
                    }
                }
                else
                {
                    currentCount = 1;
                    currentNum = String.Empty;
                }
            }
                Console.Write(maxNum);
        }
    }
}
