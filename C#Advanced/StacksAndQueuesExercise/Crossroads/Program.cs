using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int initialGreenLight = greenLight;
            int initialFreeWindow = freeWindow;
            int countPass = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    greenLight = initialGreenLight;
                    freeWindow = initialFreeWindow;

                    while (greenLight > 0 && cars.Count > 0)
                    {
                        string currentCar = cars.Peek();
                        int currentCarLength = currentCar.Length;
                        if (greenLight >= currentCarLength)
                        {
                            cars.Dequeue();
                            greenLight -= currentCarLength;
                            countPass++;
                        }

                        else if (greenLight < currentCarLength)
                        {
                            Queue<char> queueForCurrentCar = new Queue<char>();

                            for (int i = 0; i < currentCarLength; i++)
                            {
                                queueForCurrentCar.Enqueue(currentCar[i]);
                            }

                            for (int i = 0; i < greenLight; i++)
                            {
                                queueForCurrentCar.Dequeue();
                            }
                            greenLight = 0;


                            if (freeWindow >= queueForCurrentCar.Count)
                            {
                                for (int i = 0; i < queueForCurrentCar.Count; i++)
                                {
                                    queueForCurrentCar.Dequeue();
                                }
                                freeWindow = 0;
                                cars.Dequeue();
                                countPass++;
                            }

                            else if (freeWindow < queueForCurrentCar.Count)
                            {
                                char crashSymbol = currentCar[0];
                                for (int i = 0; i <= freeWindow; i++)
                                {
                                    if (queueForCurrentCar.TryPeek(out char currenSymbol))
                                    {
                                        crashSymbol = queueForCurrentCar.Dequeue();
                                    }
                                }
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {crashSymbol}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countPass} total cars passed the crossroads.");
        }
    }
}
