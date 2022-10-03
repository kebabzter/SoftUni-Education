using System;

namespace LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrFirst = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] arrSecond = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int countLeft = 0;
            int countRight = 0;
            for (int i = 0; i < Math.Min(arrFirst.Length,arrSecond.Length); i++)
            {
                if (arrFirst[i]==arrSecond[i])
                {
                    countLeft++;
                }
                else
                {
                    break;
                }
            }
            int index = 1;
            while (true)
            {
                if (arrFirst.Length-index<0||arrSecond.Length-index<0)
                {
                    break;
                }
                if (arrFirst[arrFirst.Length-index]==arrSecond[arrSecond.Length-index])
                {
                    countRight++;
                    index++;
                }
                else
                {
                    break;
                }
            }
            if (countLeft==0&&countRight==0)
            {
                Console.WriteLine("0");
            }
            else if(countLeft>countRight)
            {
                Console.WriteLine(countLeft);
            }
            else
            {
                Console.WriteLine(countRight);
            }
        }
    }
}
