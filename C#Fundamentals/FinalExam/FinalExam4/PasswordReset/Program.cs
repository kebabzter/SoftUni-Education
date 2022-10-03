using System;
using System.Linq;
using System.Text;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
   
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Done")
                {
                    break;
                }
                string[] commands = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "TakeOdd":
                        StringBuilder sb = new StringBuilder();
                        for (int i = 1; i < text.Length; i++)
                        {
                            if (i%2!=0)
                            {
                                sb.Append(text[i].ToString());
                            }
                        }
                        text = sb.ToString();
                        Console.WriteLine(text);
                        break;
                    case "Cut":
                        //•	Cut {index} {length}
                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        text=text.Remove(index, length);
                        Console.WriteLine(text);
                        break;
                    case "Substitute":
                        //•	Substitute {substring} {substitute}
                        string oldString = commands[1];
                        string newString = commands[2];
                        if (text.Contains(oldString))
                        {
                            text=text.Replace(oldString, newString);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                            continue;
                        }
                        Console.WriteLine(text);
                        break;
                }
            }
            Console.WriteLine($"Your password is: {text}");
        }
    }
}
