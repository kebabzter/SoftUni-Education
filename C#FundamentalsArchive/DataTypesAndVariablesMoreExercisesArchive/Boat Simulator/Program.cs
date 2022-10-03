using System;

namespace Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());
            int speedFirstBoat = 0;
            int speedSecondBoat = 0;
            bool winner = false;
            for (byte i = 1; i <= n; i++)
            {
                string str = Console.ReadLine();
                if (str == "UPGRADE")
                {
                    firstBoat = (char)(firstBoat + 3);
                    secondBoat = (char)(secondBoat+3);
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        speedFirstBoat += str.Length;
                        if (speedFirstBoat >= 50)
                        {
                            Console.WriteLine(firstBoat);
                            winner = true;
                            break;
                        }
                    }
                    else if (i % 2 == 0)
                    {
                        speedSecondBoat += str.Length;
                        if (speedSecondBoat >= 50)
                        {
                            Console.WriteLine(secondBoat);
                            winner = true;
                            break;
                        }
                    }
                }
            }
            if (!winner)
            {
                if (speedFirstBoat>speedSecondBoat)
                {
                    Console.WriteLine(firstBoat);
                }
                else
                {
                    Console.WriteLine(secondBoat);
                }
            }
        }
    }
}
