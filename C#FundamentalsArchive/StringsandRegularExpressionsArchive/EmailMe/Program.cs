using System;

namespace EmailMe
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            int index = email.IndexOf('@');
            string first = email.Substring(0,index);
            string second = email.Substring(index+1);
            if (SumCharecter(first)>=SumCharecter(second))
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            } 
        }
        public static int SumCharecter(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                sum += (int)str[i];
            }
            return sum;
        }
    }
}
