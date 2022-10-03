using System;

namespace IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourNum = int.Parse(Console.ReadLine());
            long result = (firstNum + secondNum) / thirdNum * fourNum;
            Console.WriteLine(result);
        }
    }
}
