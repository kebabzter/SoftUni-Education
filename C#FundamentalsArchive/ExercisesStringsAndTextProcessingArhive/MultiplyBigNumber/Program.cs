using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine().TrimStart('0');
            byte numberSecond = byte.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            int temp = 0;
            if (bigNumber == "" || numberSecond == 0)
            {
                Console.WriteLine(0);
                return;
            }
            foreach (var num in bigNumber.Reverse())
            {
                byte numberFirst = byte.Parse(num.ToString());
                int multiply = numberFirst * numberSecond + temp;
                temp = multiply / 10;
                int rest = multiply % 10;
                result.Insert(0, rest);
            }
            if (temp > 0)
            {
                result.Insert(0, temp);
            }
            Console.WriteLine(result);
        }
    }
}
