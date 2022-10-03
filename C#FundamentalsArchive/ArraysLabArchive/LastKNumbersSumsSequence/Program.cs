using System;

namespace LastKNumbersSumsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];
            numbers[0] = 1;
            for (int i = 1; i < n; i++)
            {
                for (int m = i-1; m >= i-k; m--)
                {
                    numbers[i] += numbers[m];
                    if (m==0)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
