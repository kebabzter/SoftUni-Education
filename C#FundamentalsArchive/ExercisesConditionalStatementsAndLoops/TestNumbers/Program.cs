using System;

namespace TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSum= int.Parse(Console.ReadLine());
            int sum = 0;
            int countCombin = 0;
            bool flag = false;
            for (int i = n; i >=1 ; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    int multiply = 3 * i * j;
                    sum += multiply;
                    countCombin++;
                    if (sum>=maxSum)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            Console.WriteLine($"{countCombin} combinations");
            if (sum>=maxSum)
            {
                Console.WriteLine($"Sum: {sum} >= {maxSum}");
            }
            else
            {
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
