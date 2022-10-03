using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                char letter;
                if (currentNum == 0)
                {
                    letter = ' ';
                }
                else
                {
                    int countDigits = 0;
                    int tempNum = currentNum;
                    int mainDigits = 0;
                    while (tempNum > 0)
                    {
                        countDigits++;
                        mainDigits = tempNum;
                        tempNum /= 10;
                    }
                    int offset = (mainDigits - 2) * 3;
                    if (mainDigits == 8 || mainDigits == 9)
                    {
                        offset++;
                    }
                    int letterIndex = offset + countDigits - 1;
                    letter = (char)(letterIndex + 97);
                }
                Console.Write($"{letter}");
            }
        }
    }
}
