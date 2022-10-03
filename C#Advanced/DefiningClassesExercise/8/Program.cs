using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                string[] inputEngine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputEngine[0];
                string power = inputEngine[1];
                string displacement = string.Empty;
                string efficiency = string.Empty;

                if (inputEngine.Length == 4)
                {
                    displacement = inputEngine[2];
                    efficiency = inputEngine[3];
                }

                if (inputEngine.Length == 3)
                {
                    if (char.IsDigit(inputEngine[2][0]))
                    {
                        displacement = inputEngine[2];
                        efficiency = "n/a";
                    }
                    else
                    {
                        displacement = "n/a";
                        efficiency = inputEngine[2];
                    }
                }

                if (inputEngine.Length == 2)
                {
                    displacement = "n/a";
                    efficiency = "n/a";
                }

                engines.Add(new Engine(model, power, displacement, efficiency));
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < m; i++)
            {
                string[] inputCar = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = inputCar[0];
                string engineModel = inputCar[1];
                string weight = string.Empty;
                string color = string.Empty;

                if (inputCar.Length == 4)
                {
                    weight = inputCar[2];
                    color = inputCar[3];
                }

                if (inputCar.Length == 3)
                {
                    if (char.IsDigit(inputCar[2][0]))
                    {
                        weight = inputCar[2];
                        color = "n/a";
                    }
                    else
                    {
                        weight = "n/a";
                        color = inputCar[2];
                    }
                }

                if (inputCar.Length == 2)
                {
                    weight = "n/a";
                    color = "n/a";
                }

                Engine engineCar = engines.Find(x => x.Model == engineModel);
                cars.Add(new Car(model,engineCar,weight,color));
            }

            foreach (var item in cars)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
