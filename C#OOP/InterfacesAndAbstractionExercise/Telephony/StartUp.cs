using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StationaryPhone stPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    if (numbers[i].Length == 10)
                    {
                        Console.WriteLine(smartphone.Calling(numbers[i]));
                    }
                    else
                    {
                        Console.WriteLine(stPhone.Calling(numbers[i]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartphone.Browsing(sites[i]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
