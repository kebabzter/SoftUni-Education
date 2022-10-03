using System;
using System.Linq;

namespace ManipulateArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                 .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                switch (command)
                {
                    case "Reverse":
                        arr=arr.Reverse().ToArray();
                        break;
                    case "Distinct":
                       arr= arr.Distinct().ToArray();
                        break;
                    case "Replace":
                        int index = int.Parse(input[1]);
                        string text = input[2];
                        arr[index] = text;
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",arr));
        }
    }
}
