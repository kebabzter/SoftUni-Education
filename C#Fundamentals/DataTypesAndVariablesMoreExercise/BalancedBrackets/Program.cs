using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());
            byte countOpen = 0;
            byte countClose = 0;
            string result = String.Empty;
            for (byte i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "(":
                        countOpen++;
                        break;
                    case ")":
                        countClose++;
                        if (countOpen == 1 && countClose == 1)
                        {
                            countOpen--;
                            countClose--;
                        }
                        else
                        {
                            result = "UNBALANCED";
                        }
                        break;
                }
                if (result == "UNBALANCED")
                {
                    break;
                }
            }
            if (countOpen == 0 && countClose == 0)
            {
                result = "BALANCED";
            }
            else
            {
                result = "UNBALANCED";
            }
            Console.WriteLine(result);
        }
    }
}

