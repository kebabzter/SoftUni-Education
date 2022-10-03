using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Beast!")
                {
                    break;
                }
                try
                {
                    string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = info[0];
                    int age = int.Parse(info[1]);
                   
                    switch (input)
                    {
                        case "Cat":
                            string gender = info[2];
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        case "Dog":
                            string genderD = info[2];
                            Dog dog = new Dog(name, age, genderD);
                            Console.WriteLine(dog);
                            break;
                        case "Frog":
                            string genderF = info[2];
                            Frog frog = new Frog(name, age, genderF);
                            Console.WriteLine(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(tomcat);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
