using System;

namespace _5DifferentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
           int b = int.Parse(Console.ReadLine());
            if (Math.Abs(b-a)>=4)
            {
                for (int i = a; i <= b; i++)
                {
                    for (int j = a; j <= b; j++)
                    {
                        for (int k = a; k <= b; k++)
                        {
                            for (int l = a; l <= b; l++)
                            {
                                for (int m = a; m <= b; m++)
                                {
                                    if (i < j && j < k && k < l && l < m)
                                    {
                                        Console.WriteLine($"{i} {j} {k} {l} {m}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
