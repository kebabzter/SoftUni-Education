using System;
using System.Collections.Generic;
using System.Text;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<int> numbers = new List<int>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    numbers.Add(int.Parse(text[i].ToString()));
                }
                else
                {
                    sb.Append(text[i]);
                }
            }
            int index = 0;
            StringBuilder result = new StringBuilder();
            for (int j = 0; j < numbers.Count; j++)
            {
                if (j%2==0)
                {
                    if (index + numbers[j] > sb.Length)
                    {
                       result.Append(sb.ToString().Substring(index));
                    }
                    else
                    {
                        result.Append(sb.ToString().Substring(index, numbers[j]));
                    }
                    index += numbers[j];
                }
                else
                {
                    index += numbers[j];
                }
            }
            Console.WriteLine(result);
        }
    }
}

