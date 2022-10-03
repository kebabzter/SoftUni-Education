using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person();
            personOne.Name = "Pesho";
            personOne.Age = 20;

            Person personTwo = new Person();
            personOne.Name = "Gosho";
            personOne.Age = 18;

            Person personThree = new Person()
            {
                Name="Stamat",
                Age=43
            };
        }
    }
}
