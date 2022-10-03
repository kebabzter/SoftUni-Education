using System;
using System.Text;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weapon = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="Done")
                {
                    break;
                }

                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string position = commands[1];
                if (command=="Move")
                {
                    int index = int.Parse(commands[2]);
                    if (position=="Left")
                    {
                        if (index<=0 || index>=weapon.Length)
                        {
                            continue;
                        }
                        string temp = weapon[index];
                        weapon[index] = weapon[index-1];
                        weapon[index - 1] = temp;
                    }
                    else if (position=="Right")
                    {
                        if (index<0||index>=weapon.Length-1)
                        {
                            continue;
                        }
                        string temp = weapon[index];
                        weapon[index] = weapon[index + 1];
                        weapon[index + 1] = temp;
                    }
                }
                else if (command=="Check")
                {
                    if (position=="Even")
                    {
                        for (int i = 0; i < weapon.Length; i++)
                        {
                            if (i%2==0)
                            {
                                Console.Write($"{weapon[i]} ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (position=="Odd")
                    {
                        for (int i = 0; i < weapon.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write($"{weapon[i]} ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < weapon.Length; i++)
            {
                sb.Append(weapon[i]);
            }
            Console.WriteLine($"You crafted {sb}!");
        }
    }
}
