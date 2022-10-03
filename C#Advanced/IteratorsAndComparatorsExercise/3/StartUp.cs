using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            while (true)
            {
                var tokens = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0]=="END")
                {
                    break;
                }
                else if (tokens[0]=="Push")
                {
                    stack.Push(tokens.Skip(1).Select(x=>x.Split(",").First()).ToArray());
                }
                else if (tokens[0]=="Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
