using System;

namespace KarateStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int count=0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='>')
                {
                    count += int.Parse(input[i+1].ToString());
                    input = input.Remove(i + 1, 1);
                    count--;
                }
                else if(count>0)
                {
                   input= input.Remove(i,1);
                    i--;
                    count--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
