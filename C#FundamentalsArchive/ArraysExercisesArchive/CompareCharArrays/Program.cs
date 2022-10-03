using System;
using System.Linq;

namespace CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arrFirst = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] arrSecond = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            for (int i = 0; i < Math.Min(arrFirst.Length,arrSecond.Length); i++)
            {
                if (arrFirst[i]==arrSecond[i])
                {
                    if (i== Math.Min(arrFirst.Length, arrSecond.Length)-1)
                    {
                        if (arrFirst.Length>arrSecond.Length)
                        {
                            Console.WriteLine(string.Join("", arrSecond));
                            Console.WriteLine(string.Join("", arrFirst));
                        }
                        else
                        {
                            Console.WriteLine(string.Join("", arrFirst));
                            Console.WriteLine(string.Join("", arrSecond));
                        }
                    }
                    continue;
                }
                else if (arrFirst[i]>arrSecond[i])
                {
                    Console.WriteLine(string.Join("",arrSecond));
                    Console.WriteLine(string.Join("", arrFirst));
                    break;
                }
                else
                {
                    Console.WriteLine(string.Join("", arrFirst));
                    Console.WriteLine(string.Join("", arrSecond));
                    break;
                }
            }
        }
    }
}
