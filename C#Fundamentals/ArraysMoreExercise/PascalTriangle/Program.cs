using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int elem = 1;
            for (int i = 0; i < n; i++)
            {
                int[] arr = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        elem = 1;
                    }
                    else
                    {
                        elem = elem * (i - j + 1) / j;
                    }
                    arr[j] = elem;
                }
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
