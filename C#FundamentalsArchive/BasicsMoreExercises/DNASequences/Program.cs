using System;

namespace DNASequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int matchSum = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 4; i++)
            {
                string symbolFirst = string.Empty;
                if (i == 1)
                {
                    symbolFirst = "A";
                }
                else if (i == 2)
                {
                    symbolFirst = "C";
                }
                else if (i == 3)
                {
                    symbolFirst = "G";
                }
                else if (i == 4)
                {
                    symbolFirst = "T";
                }
                for (int j = 1; j <= 4; j++)
                {
                    string symbolSecond = string.Empty;
                    if (j == 1)
                    {
                        symbolSecond = "A";
                    }
                    else if (j == 2)
                    {
                        symbolSecond = "C";
                    }
                    else if (j == 3)
                    {
                        symbolSecond = "G";
                    }
                    else if (j == 4)
                    {
                        symbolSecond = "T";
                    }
                    for (int k = 1; k <= 4; k++)
                    {
                        string symbolThree = string.Empty;
                        if (k == 1)
                        {
                            symbolThree = "A";
                        }
                        else if (k == 2)
                        {
                            symbolThree = "C";
                        }
                        else if (k == 3)
                        {
                            symbolThree = "G";
                        }
                        else if (k == 4)
                        {
                            symbolThree = "T";
                        }

                        if (i + j + k >= matchSum)
                        {
                            Console.Write($"O{symbolFirst}{symbolSecond}{symbolThree}O ");
                        }
                        else
                        {
                            Console.Write($"X{symbolFirst}{symbolSecond}{symbolThree}X ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
