using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondLine = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> lilies = new Stack<int>(firstLine);
            Queue<int> roses = new Queue<int>(secondLine);
            int wreath = 0;
            int sum = 0;
            int sumOther = 0;
            while (lilies.Count>0&&roses.Count>0)
            {
                int firstNum = lilies.Peek();
                int secondNum = roses.Peek();
                sum = firstNum+secondNum;
                if (sum==15)
                {
                    wreath++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum>15)
                {
                    firstNum -= 2;
                    lilies.Push(firstNum);
                }
                else
                {
                    sumOther += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
               
            }
            int moreWreath = sumOther / 15;
            wreath += moreWreath;
            if (wreath>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreath} wreaths more!");
            }
        }
    }
}
