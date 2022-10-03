using System;
using System.Collections.Generic;

namespace FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emailBook = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                string email = Console.ReadLine();
                int index = email.LastIndexOf('.')+1;
                if (email.Substring(index)=="us"|| email.Substring(index) == "uk")
                {
                    continue;
                }
                if (emailBook.ContainsKey(input))
                {
                    emailBook[input] = email;
                }
                else
                {
                    emailBook.Add(input, email);
                }
            }
            foreach (var item in emailBook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
