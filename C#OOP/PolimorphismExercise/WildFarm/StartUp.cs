using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] currentAnimal = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] currentFood = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Animal animal = null;
                    string typeOfAnimal = currentAnimal[0];
                    string animalName = currentAnimal[1];
                    double animalWeight = double.Parse(currentAnimal[2]);
                    double wingSize;
                    string livingRegion;
                    string breed;
                    switch (typeOfAnimal)
                    {
                        case "Hen":
                            wingSize = double.Parse(currentAnimal[3]);
                            animal = new Hen(animalName, animalWeight, wingSize);
                            break;
                        case "Owl":
                            wingSize = double.Parse(currentAnimal[3]);
                            animal = new Owl(animalName, animalWeight, wingSize);
                            break;
                        case "Dog":
                            livingRegion = currentAnimal[3];
                            animal = new Dog(animalName, animalWeight, livingRegion);
                            break;
                        case "Mouse":
                            livingRegion = currentAnimal[3];
                            animal = new Mouse(animalName, animalWeight, livingRegion);
                            break;
                        case "Cat":
                            livingRegion = currentAnimal[3];
                            breed = currentAnimal[4];
                            animal = new Cat(animalName, animalWeight, livingRegion, breed);
                            break;
                        case "Tiger":
                            livingRegion = currentAnimal[3];
                            breed = currentAnimal[4];
                            animal = new Tiger(animalName, animalWeight, livingRegion, breed);
                            break;
                    }
                    animals.Add(animal);

                    Food food = null;
                    string typeOfFood = currentFood[0];
                    int foodQuantity = int.Parse(currentFood[1]);
                    switch (typeOfFood)
                    {
                        case "Vegetable":
                            food = new Vegetable(foodQuantity);
                            break;
                        case "Seeds":
                            food = new Seeds(foodQuantity);
                            break;
                        case "Fruit":
                            food = new Fruit(foodQuantity);
                            break;
                        case "Meat":
                            food = new Meat(foodQuantity);
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(animal.ProduceSound());
                    animal.ValidateFood(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
