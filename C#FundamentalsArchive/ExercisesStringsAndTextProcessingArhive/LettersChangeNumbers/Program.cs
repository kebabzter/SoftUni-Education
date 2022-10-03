using System;
using System.Linq;
namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { " ", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            decimal sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string arrElement = input[i].ToString();
                char firstLetter = arrElement[0];
                char lastLetter = arrElement[arrElement.Length - 1];
                decimal number = decimal.Parse(arrElement.Substring(1, arrElement.Length - 2));
                decimal firstUpper = firstLetter - 64;
                decimal firstLower = firstLetter - 96;
                decimal lastUpper = lastLetter - 64;
                decimal lastLower = lastLetter - 96;
                if (65 <= firstLetter && firstLetter <= 90)
                {
                    number /= firstUpper;
                }
                else
                {
                    number *= firstLower;
                }
                if (65 <= lastLetter && lastLetter <= 90)
                {
                    number -= lastUpper;
                }
                else
                {
                    number += lastLower;
                }
                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
