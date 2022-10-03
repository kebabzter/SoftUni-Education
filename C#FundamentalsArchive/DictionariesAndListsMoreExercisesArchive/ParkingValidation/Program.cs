using System;
using System.Collections.Generic;

namespace ParkingValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> validationParking = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] parking = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = parking[0];
                string user = parking[1];
                if (command == "register")
                {
                    string licensePlateNumber = parking[2];
                    if (validationParking.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {validationParking[user]}");
                    }
                    else if (!((licensePlateNumber.Length == 8) &&
                    (licensePlateNumber[0] >= 65 && licensePlateNumber[0] <= 90 && licensePlateNumber[1] >= 65 && licensePlateNumber[1] <= 90 &&
                     licensePlateNumber[7] >= 65 && licensePlateNumber[7] <= 90 && licensePlateNumber[6] >= 65 && licensePlateNumber[6] <= 90) &&
                     char.IsDigit(licensePlateNumber[2]) && char.IsDigit(licensePlateNumber[3]) && char.IsDigit(licensePlateNumber[4]) && char.IsDigit(licensePlateNumber[5])))
                    {
                        Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
                    }
                    else if (validationParking.ContainsValue(licensePlateNumber))
                    {
                        Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                    }
                    else if (!(validationParking.ContainsKey(user)))
                    {
                        validationParking.Add(user, licensePlateNumber);
                        Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (validationParking.ContainsKey(user))
                    {
                        validationParking.Remove(user);
                        Console.WriteLine($"user {user} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                }
            }
            foreach (var item in validationParking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
