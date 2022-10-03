using System;

namespace TouristInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string imperialUnit = Console.ReadLine();
            double valueConvert = double.Parse(Console.ReadLine());
            double convertValue = 0;
            string convertUnit = string.Empty;
            switch (imperialUnit)
            {
                case "miles":
                    convertValue=valueConvert*1.6;
                    convertUnit = "kilometers";
                    break;
                case "inches":
                    convertValue = valueConvert * 2.54;
                    convertUnit = "centimeters";
                    break;
                case "feet":
                    convertValue = valueConvert * 30;
                    convertUnit = "centimeters";
                    break;
                case "yards":
                    convertValue = valueConvert * 0.91;
                    convertUnit = "meters";
                    break;
                case "gallons":
                    convertValue = valueConvert * 3.8;
                    convertUnit = "liters";
                    break;
            }
            Console.WriteLine($"{valueConvert} {imperialUnit} = {convertValue:f2} {convertUnit}");
        }
    }
}
