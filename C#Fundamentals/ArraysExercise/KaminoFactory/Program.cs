using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int maxCount = 0;
            int bestIndex = 0;
            int bestSum = 0;
            int[] bestArr = new int[length];
            int bestSample = 1;
            int sample = 0;
            while (true)
            {
                string input = Console.ReadLine();
                sample++;
                if (input== "Clone them!")
                {
                    break;
                }
                int[] arr = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int sum = arr.Sum();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i]==0)
                    {
                        continue;
                    }
                    int currentCount = 1;
                    for (int j = i+1; j < arr.Length; j++)
                    {
                        if (arr[i]==arr[j])
                        {
                            currentCount++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currentCount>maxCount)
                    {
                        maxCount = currentCount;
                        bestIndex = i;
                        bestSum = sum;
                        bestArr = arr;
                        bestSample = sample;
                    }
                    else if (currentCount==maxCount)
                    {
                        if (i<bestIndex)
                        {
                            maxCount = currentCount;
                            bestIndex = i;
                            bestSum = sum;
                            bestArr = arr;
                            bestSample = sample;
                        }
                        else if (i==bestIndex&&sum>bestSum)
                        {
                            bestSum = sum;
                            maxCount = currentCount;
                            bestIndex = i;
                            bestArr = arr;
                            bestSample = sample;
                        }
                    }
                }
            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestArr));
        }
    }
}
