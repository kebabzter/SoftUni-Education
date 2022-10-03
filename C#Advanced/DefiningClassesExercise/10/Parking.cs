using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacityParking)
        {
            cars = new List<Car>();
            capacity = capacityParking;
        }

       public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }
            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            Car car = cars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber);
            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(car);
            return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Find(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currentNumber in registrationNumbers)
            {
                cars.RemoveAll(x => x.RegistrationNumber == currentNumber);
            }
        }


    }
}
