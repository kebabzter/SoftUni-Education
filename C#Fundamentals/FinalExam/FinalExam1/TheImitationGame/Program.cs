using System;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Decode")
                {
                    break;
                }
                string[] commands = input.Split("|",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Move":
                        int count = int.Parse(commands[1]);
                        string moveStr = message.Substring(0, count);
                        message = message.Substring(count) + moveStr;
                        break;
                    case "Insert":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];
                        if (index<0)
                        {
                            index = 0;
                        }
                        message = message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string oldStr = commands[1];
                        string newStr = commands[2];
                        while (message.Contains(oldStr))
                        {
                            message = message.Replace(oldStr, newStr);
                        }
                        break;
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
