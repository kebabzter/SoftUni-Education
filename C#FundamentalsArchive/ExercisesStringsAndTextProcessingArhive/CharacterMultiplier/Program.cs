using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string first = input[0];
            string second = input[1];
            int minLength = Math.Min(first.Length,second.Length);
            int sum = 0;
            for (int i = 0; i < minLength; i++)
            {
                int multiply = first[i] * second[i];
                sum += multiply;
            }
            if (first.Length>second.Length)
            {
                for (int i = minLength; i < first.Length; i++)
                {
                    sum += first[i];
                }
            }
            else
            {
                for (int i = minLength; i < second.Length; i++)
                {
                    sum += second[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
