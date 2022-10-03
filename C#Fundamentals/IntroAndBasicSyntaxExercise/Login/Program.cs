using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string password = string.Concat(user.Reverse());
            int count = 0;
            string input = Console.ReadLine();
            while (input != password)
            {
                count++;
                if (count == 4)
                {
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }
            if (count == 4)
            {
                Console.WriteLine($"User {user} blocked!");
            }
            else
            {
                Console.WriteLine($"User {user} logged in.");
            }
        }
    }
}
