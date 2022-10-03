using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> users = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                users.Add(Console.ReadLine());
            }

            foreach (var item in users)
            {
                Console.WriteLine(item);
            }

        }
    }
}
