using System;
using System.Globalization;
using System.Linq;

namespace CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(dateOne, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(dateTwo, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime[] officialHolidays = new DateTime[11];
            officialHolidays[0] = new DateTime(2015, 01, 01);
            officialHolidays[1] = new DateTime(2015, 03, 03);
            officialHolidays[2] = new DateTime(2015, 05, 01);
            officialHolidays[3] = new DateTime(2015, 05, 06);
            officialHolidays[4] = new DateTime(2015, 05, 24);
            officialHolidays[5] = new DateTime(2015, 09, 06);
            officialHolidays[6] = new DateTime(2015, 09, 22);
            officialHolidays[7] = new DateTime(2015, 11, 01);
            officialHolidays[8] = new DateTime(2015, 12, 24);
            officialHolidays[9] = new DateTime(2015, 12, 25);
            officialHolidays[10] = new DateTime(2015, 12, 26);
            int count = 0;
            for (DateTime i = startDate; i <= endDate; i=i.AddDays(1))
            {
                var day = i.DayOfWeek;
               if(!officialHolidays.Any(h => h.Day == i.Day && h.Month == i.Month) && !(i.DayOfWeek == DayOfWeek.Saturday) && !(i.DayOfWeek == DayOfWeek.Sunday))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
