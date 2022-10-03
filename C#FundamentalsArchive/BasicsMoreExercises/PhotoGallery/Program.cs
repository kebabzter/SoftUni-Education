using System;

namespace PhotoGallery
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine($"Name: DSC_{number:d4}.jpg");
            Console.WriteLine($"Date Taken: {day:d2}/{month:d2}/{year} {hours:d2}:{minutes:d2}");
            string printSize = string.Empty;
            double sizePrint = 0;
            if (size<1000)
            {
                printSize = "B";
                sizePrint = size;
            }
            else if (size/1000<1000)
            {
                printSize = "KB";
                sizePrint = size / 1000;
            }
            else if (size/1000000<1000)
            {
                printSize = "MB";
                sizePrint = 1.0*size / 1000000;
            }
            Console.WriteLine($"Size: {sizePrint}{printSize}");
            string orientation = string.Empty;
            if (width==height)
            {
                orientation="square";
            }
            else if (width>height)
            {
                orientation = "landscape";
            }
            else
            {
                orientation = "portrait";
            }
            Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
        }
    }
}
