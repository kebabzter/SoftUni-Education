using System;
using System.Text.RegularExpressions;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input=Console.ReadLine().Split(new string[]{" ", "/", "\\", "(", ")"},StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"^([A-z]([A-z|0-9|_]){2,24})$";
            Regex regex = new Regex(pattern);
            int maxSum = int.MinValue;
            string maxUserOne = String.Empty;
            string maxUserTwo = String.Empty;
            for (int i = 0; i < input.Length-1; i++)
            {
                if (regex.IsMatch(input[i]))
                {
                    for (int j = i+1; j < input.Length; j++)
                    {
                        if (regex.IsMatch(input[j]))
                        {
                            int currentSum = input[i].Length + input[j].Length;
                            if (currentSum > maxSum)
                            {
                                maxSum = currentSum;
                                maxUserOne = input[i];
                                maxUserTwo = input[j];
                            }
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(maxUserOne);
            Console.WriteLine(maxUserTwo);
        }
    }
}
