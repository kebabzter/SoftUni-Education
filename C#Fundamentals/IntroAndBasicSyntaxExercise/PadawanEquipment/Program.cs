using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceLightsabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());
            double countLightsabers = countOfStudents + Math.Ceiling(countOfStudents * 0.1);
            double price = countLightsabers * priceLightsabers + countOfStudents * priceRobes + priceBelts * (countOfStudents - countOfStudents / 6);
            if (price <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {price:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {price - amountOfMoney:f2}lv more.");
            }
        }
    }
}
