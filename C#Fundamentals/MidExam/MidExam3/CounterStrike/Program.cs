using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int countWon = 0;
            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                initialEnergy -= distance;
                if (initialEnergy >= 0)
                {
                    countWon++;
                    if (countWon % 3 == 0)
                    {
                        initialEnergy += countWon;
                    }
                }
                if (initialEnergy < 0)
                {
                    initialEnergy += distance;
                    Console.WriteLine($"Not enough energy! Game ends with {countWon} won battles and {initialEnergy} energy");
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "End of battle")
            {
                Console.WriteLine($"Won battles: {countWon}. Energy left: {initialEnergy}");
            }
        }
    }
}
