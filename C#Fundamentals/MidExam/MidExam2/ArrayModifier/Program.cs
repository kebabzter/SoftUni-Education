using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int index1 = 0;
                int index2 = 0;
                switch (commandArr[0])
                {
                    case "swap":
                        index1 = int.Parse(commandArr[1]);
                        index2 = int.Parse(commandArr[2]);
                        int temp = initialArray[index1];
                        initialArray[index1] = initialArray[index2];
                        initialArray[index2] = temp;
                        break;
                    case "multiply":
                        index1 = int.Parse(commandArr[1]);
                        index2 = int.Parse(commandArr[2]);
                        initialArray[index1] = initialArray[index1] * initialArray[index2];
                        break;
                    case "decrease":
                        for (int i = 0; i < initialArray.Length; i++)
                        {
                            initialArray[i]--;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", initialArray));
        }
    }
}
