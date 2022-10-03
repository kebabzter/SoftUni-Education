using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    { 
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] cars = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = cars[0];
                string carNumber = cars[1];
                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    parking.Remove(carNumber);
                }
            }

            foreach (var item in parking)
            {
                Console.WriteLine(item);
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
