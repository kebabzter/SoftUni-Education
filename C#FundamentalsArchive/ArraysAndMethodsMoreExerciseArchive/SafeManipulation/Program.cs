using System;
using System.Linq;

namespace SafeManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0]=="END")
                {
                    break;
                }
                string command = input[0];
                switch (command)
                {
                    case "Reverse":
                        arr = arr.Reverse().ToArray();
                        break;
                    case "Distinct":
                        arr = arr.Distinct().ToArray();
                        break;
                    case "Replace":
                        int index = int.Parse(input[1]);
                        string text = input[2];
                        if (index < 0 || index>=arr.Length)
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        arr[index] = text;
                        break;
                        default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
