using System;
using System.Text;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0]== "Travel")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Add Stop":
                        int index = int.Parse(commands[1]);
                        string str = commands[2];
                        if (index>=0 && index<text.Length)
                        {
                            text = text.Insert(index, str);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && endIndex<text.Length)
                        {
                            text = text.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        break;
                    case "Switch":
                        string oldString = commands[1];
                        string newString = commands[2];
                        
                        if (text.Contains(oldString))
                        {
                            StringBuilder sb = new StringBuilder(text);
                            sb = sb.Replace(oldString, newString);
                            text = sb.ToString();
                           
                        }
                        break;
                }
                Console.WriteLine(text);
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
