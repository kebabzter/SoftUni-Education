using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string strFirst = Console.ReadLine().ToLower();
            string strSecond = Console.ReadLine().ToLower();
            while (strSecond.Contains(strFirst))
            {
                int index = strSecond.IndexOf(strFirst);
                strSecond = strSecond.Remove(index, strFirst.Length);
            }
            Console.WriteLine(strSecond);
        }
    }
}
