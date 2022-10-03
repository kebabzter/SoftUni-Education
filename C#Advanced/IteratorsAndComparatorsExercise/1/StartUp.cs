using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            ListyIterator<string> listy = null;

            while ((command=Console.ReadLine())!="END")
            {
                var tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0]=="Create")
                {
                    listy = new ListyIterator<string>(tokens.Skip(1).ToArray());
                }
                else if (tokens[0]=="Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (tokens[0]=="Print")
                {
                    try
                    {
                        listy.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (tokens[0]=="HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (tokens[0]=="PrintAll")
                {
                    listy.PrintAll();
                }
            }
        }
    }
}
