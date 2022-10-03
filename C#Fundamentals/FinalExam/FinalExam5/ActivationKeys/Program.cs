using System;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Generate")
                {
                    break;
                }

                string[] commands = input.Split(">>>",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Contains":
                        if (text.Contains(commands[1]))
                        {
                            Console.WriteLine($"{text} contains {commands[1]}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIndex = int.Parse(commands[2]);
                        int endIndex = int.Parse(commands[3]);
                        string changeString = text.Substring(startIndex, endIndex - startIndex);
                        if (commands[1] == "Upper")
                        {
                            text = text.Substring(0, startIndex) + changeString.ToUpper() + text.Substring(endIndex);
                        }
                        else if (commands[1]=="Lower")
                        {
                            text = text.Substring(0, startIndex) + changeString.ToLower() + text.Substring(endIndex);
                        }
                        Console.WriteLine(text);
                        break;
                    case "Slice":
                        int startIdx = int.Parse(commands[1]);
                        int endIdx = int.Parse(commands[2]);
                        text = text.Remove(startIdx, endIdx - startIdx);
                        Console.WriteLine(text);
                        break;
                }

            }
            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
