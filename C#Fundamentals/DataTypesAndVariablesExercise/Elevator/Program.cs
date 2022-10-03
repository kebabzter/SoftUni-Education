using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int countCourses = (int)Math.Ceiling((double)numberPeople / capacity);
            Console.WriteLine(countCourses);
        }
    }
}
