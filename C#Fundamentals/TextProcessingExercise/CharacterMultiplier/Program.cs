using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string first = input[0];
            string second = input[1];
            int minLength = Math.Min(first.Length,second.Length);
            int sum = 0;
            for (int i = 0; i < minLength; i++)
            {
                sum += first[i] * second[i];
            }
            if (first.Length > second.Length)
            {
                sum += SumChar(minLength,first);
            }
            else if(second.Length>first.Length)
            {
                sum += SumChar(minLength,second);
            }
            Console.WriteLine(sum);
        }
        public static int SumChar(int index,string text)
        {
            int sum = 0;
            for (int i = index; i < text.Length; i++)
            {
                sum += text[i];
            }
            return sum;
        }
    }
}
