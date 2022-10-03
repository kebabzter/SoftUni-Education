using System;

namespace DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key= byte.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());
            for (byte i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                Console.Write((char)(letter+key));
            }
        }
    }
}
