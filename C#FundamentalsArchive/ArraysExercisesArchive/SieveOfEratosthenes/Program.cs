using System;
using System.Collections.Generic;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 2; i <=n; i++)
            {
                bool flag = true;
                for (int j = 2; j <i; j++)
                {
                    if (i%j==0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    list.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
