using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="END")
                {
                    break;
                }

                if (Palindrome(input))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool Palindrome(string text)
        {
            bool isPalindrome = true;
            for (int i = 0; i < text.Length/2; i++)
            {
                if (text[i]!=text[text.Length-1-i])
                {
                    isPalindrome=false;
                    break;
                }
            }
            return isPalindrome;
        }
    }
}
