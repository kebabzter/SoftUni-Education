using System;

namespace TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{FahrenheitCelsius(double.Parse(Console.ReadLine())):f2}");
        }
        static double FahrenheitCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
