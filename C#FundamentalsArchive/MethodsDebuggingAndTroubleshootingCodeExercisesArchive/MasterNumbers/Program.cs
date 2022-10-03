using System;

namespace MasterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                if ((Palindrome(i.ToString()))&&(SumDigits(i) % 7 == 0)&&(EvenDigits(i)))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool EvenDigits(int number)
        {
            while (number > 0)
            {
                int currentNum = number % 10;
                if (currentNum % 2 == 0)
                {
                    return true;
                }
                number /= 10;
            }
            return false;
        }
        static int SumDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
        static bool Palindrome(string text)
        {
            bool isPalindrome = true;
            for (int i = 0; i < text.Length / 2; i++)
            {
                if (text[i] != text[text.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }
    }
}
