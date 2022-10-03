using System;

namespace BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            byte countStudents = byte.Parse(Console.ReadLine());
            byte countLectures = byte.Parse(Console.ReadLine());
            byte initialBonus = byte.Parse(Console.ReadLine());
            double maxBonus = 0;
            double lectures = 0;
            if (countLectures > 0)
            {
                for (byte i = 0; i < countStudents; i++)
                {
                    double bonus = 0;
                    double attendances = double.Parse(Console.ReadLine());
                    bonus = (1.0 * attendances) / (countLectures) * ((initialBonus + 5) * 1.0);
                    if (bonus > maxBonus)
                    {
                        maxBonus = bonus;
                        lectures = attendances;
                    }
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {lectures} lectures.");
        }
    }
}
