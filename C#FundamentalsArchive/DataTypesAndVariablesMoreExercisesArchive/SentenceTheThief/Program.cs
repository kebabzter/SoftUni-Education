using System;

namespace SentenceTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            sbyte n = sbyte.Parse(Console.ReadLine());
            long maxnumber = long.MinValue;
            for (int i = 1; i <= n; i++)
            {
                var number = long.Parse(Console.ReadLine());
                switch (type)
                {
                    case "sbyte":
                        if (number <= sbyte.MaxValue && number > maxnumber)
                        {
                            maxnumber = number;
                        }
                        break;
                    case "int":
                        if (number <= int.MaxValue && number > maxnumber)
                        {
                            maxnumber = number;
                        }
                        break;
                    case "long":
                        if (number <= long.MaxValue && number > maxnumber)
                        {
                            maxnumber = number;
                        }
                        break;
                }
            }
            long sentence = 0;
            if (maxnumber >= 0)
            {
                sentence = (long)Math.Ceiling(Math.Abs((decimal)maxnumber / sbyte.MaxValue));
            }
            else
            {
                sentence = (long)Math.Ceiling(Math.Abs((decimal)maxnumber / sbyte.MinValue));
            }
            if (Math.Abs(sentence) <= 1)
            {
                Console.WriteLine($"Prisoner with id {maxnumber} is sentenced to {sentence} year");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {maxnumber} is sentenced to {sentence} years");
            }

        }
    }
}
