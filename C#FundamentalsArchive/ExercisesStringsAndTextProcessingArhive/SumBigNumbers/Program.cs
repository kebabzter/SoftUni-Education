using System;
using System.Text;


namespace SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string n1 = Console.ReadLine().TrimStart('0');
            string n2 = Console.ReadLine().TrimStart('0');
            StringBuilder result = new StringBuilder();
            if (n1.Length > n2.Length)
            {
                n2 = n2.PadLeft(n1.Length, '0');
            }
            else if (n1.Length < n2.Length)
            {
                n1 = n1.PadLeft(n2.Length, '0');
            }
            char[] str1 = n1.ToCharArray();
            char[] str2 = n2.ToCharArray();

            sbyte remainder = 0;
            sbyte addition = 0;
            for (int i = str1.Length - 1; i >= 0; i--)
            {
                sbyte num1 = sbyte.Parse(str1[i].ToString());
                sbyte num2 = sbyte.Parse(str2[i].ToString());
                num1 += addition;
                addition = 0;
                if (num1 + num2 < 10)
                {
                    result.Append(num1 + num2);
                }
                else
                {
                    remainder = (sbyte)((num1 + num2) % 10);
                    result.Append(remainder);
                    addition = (sbyte)((num1 + num2) / 10);
                }
            }
            if (addition != 0)
            {
                result.Append(addition);
            }

            char[] endResult = result.ToString().ToCharArray();
            Array.Reverse(endResult);

            Console.WriteLine(string.Join("", endResult));
        }
    }
}
