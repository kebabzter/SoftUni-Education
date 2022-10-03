using System;
using System.Collections.Generic;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Complete")
                {
                    break;
                }
                string[] commands = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Make":
                        if (commands[1]=="Upper")
                        {
                            text = text.ToUpper();
                        }
                        else
                        {
                            text = text.ToLower();
                        }
                        Console.WriteLine(text);
                        break;
                    case "GetDomain":
                        int count = int.Parse(commands[1]);
                        Console.WriteLine(text.Substring(text.Length-count));
                        break;
                    case "GetUsername":
                        if (text.Contains("@"))
                        {
                            int index = text.IndexOf('@');
                            Console.WriteLine(text.Substring(0,index));
                        }
                        else
                        {
                            Console.WriteLine($"The email {text} doesn't contain the @ symbol.");
                        }
                        break;
                    case "Replace":
                        char symbol = char.Parse(commands[1]);
                        text = text.Replace(symbol, '-');
                        Console.WriteLine(text);
                        break;
                    case "Encrypt":
                        List<int> code = new List<int>();
                        for (int i = 0; i < text.Length; i++)
                        {
                            code.Add(text[i]);
                        }
                        Console.WriteLine(string.Join(" ",code));
                        break;
                }
            }
        }
    }
}
