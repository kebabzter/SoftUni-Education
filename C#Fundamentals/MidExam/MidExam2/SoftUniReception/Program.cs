using System;

namespace SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            byte employeeEfficiencyOne = byte.Parse(Console.ReadLine());
            byte employeeEfficiencyTwo = byte.Parse(Console.ReadLine());
            byte employeeEfficiencyThree = byte.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int allEmployee = employeeEfficiencyOne + employeeEfficiencyTwo + employeeEfficiencyThree;
            int hours = 0;
            int breakCount = 0;
            while (studentsCount > 0)
            {
                studentsCount -= allEmployee;
                hours++;
                breakCount++;
                if (breakCount == 3 && studentsCount != 0)
                {
                    hours++;
                    breakCount = 0;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
