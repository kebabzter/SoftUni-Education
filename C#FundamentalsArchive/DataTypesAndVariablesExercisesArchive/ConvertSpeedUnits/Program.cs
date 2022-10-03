using System;

namespace ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int hours= int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds= int.Parse(Console.ReadLine());
            float metersPerSecond = (float)distance/(seconds+minutes*60+hours*3600);
            float kilometers = ((float)distance / 1000)/(float)(hours+minutes/60.0+seconds/3600.0);
            float miles= ((float)distance/ 1609) / (float)(hours + minutes / 60.0 + seconds / 3600.0);
            Console.WriteLine($"{metersPerSecond}");
            Console.WriteLine($"{kilometers}");
            Console.WriteLine($"{miles}");
        }
    }
}
