using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "Reveal")
                {
                    break;
                }

                string[] commands = input.Split(":|:",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string strReverse = commands[1];
                        if (message.Contains(strReverse))
                        {
                            message = message.Remove(message.IndexOf(strReverse),strReverse.Length);
                            strReverse = string.Concat(strReverse.ToCharArray().Reverse());
                            message += strReverse;
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        string oldString = commands[1];
                        string newString = commands[2];
                        while (message.Contains(oldString))
                        {
                            message = message.Replace(oldString, newString);
                        }
                        Console.WriteLine(message);
                        break;
                }
                
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
