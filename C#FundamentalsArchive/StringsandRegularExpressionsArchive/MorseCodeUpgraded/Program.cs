using System;
using System.Linq;

namespace MorseCodeUpgraded
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');
            for (int i = 0; i < input.Length; i++)
            {
                int code = 0;
                string currentStr = input[i];
                int countZero = currentStr.Where(x => x == '0').Count();
                int countOne = currentStr.Where(x => x == '1').Count();
                code = countZero * 3 + countOne * 5;
                int tempCount = 1;
                for (int j = 0; j < currentStr.Length-1; j++)
                {
                    if (currentStr[j]==currentStr[j+1])
                    {
                        tempCount++;
                    }
                    else
                    {
                        if (tempCount>1)
                        {
                            code += tempCount;
                            tempCount = 1;
                        }
                    }
                }
                if (tempCount>1)
                {
                    code += tempCount;
                }
                Console.Write((char)code);
            }
        }
    }
}
