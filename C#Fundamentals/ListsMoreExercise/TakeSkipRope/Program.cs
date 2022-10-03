using System;
using System.Linq;
using System.Text;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string digits = string.Concat(input.Where(x => char.IsDigit(x)));
            string other = string.Concat(input.Where(x => !char.IsDigit(x)));
            StringBuilder result = new StringBuilder();
            int index = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                int number = int.Parse(digits[i].ToString());
                if (i%2==0)
                {
                    if (index+number>other.Length)
                    {
                        result.Append(other.Substring(index));
                    }
                    else
                    {
                        result.Append(other.Substring(index,number));
                    }                    
                }
                index += number;
            }
            Console.WriteLine(result);
        }
    }
}
