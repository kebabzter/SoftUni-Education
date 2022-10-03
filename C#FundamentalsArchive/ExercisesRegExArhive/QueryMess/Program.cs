using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([^?]*)=([^?]*)";
            Regex regex = new Regex(pattern);
          
            while (true)
            {
                string input = Console.ReadLine();
                Dictionary<string, List<string>> dictMess = new Dictionary<string, List<string>>();
                if (input=="END")
                {
                    break;
                }
                for (int i = 0; i < input.Length-1; i++)
                {
                    if (input[i] == input[i + 1] && input[i] =='+')
                    {
                        input = input.Remove(i + 1, 1);
                        i--;
                    }
                }
                for (int i = 0; i < input.Length - 3; i+=3)
                {
                    if ((input[i] == input[i + 3] && input[i] == '%')&&(input[i+1] == input[i + 4] && input[i+1] == '2') &&(input[i+2] == input[i + 5] && input[i+2] == '0'))
                    {
                        input = input.Remove(i + 3, 3);
                        i-=3;
                    }
                }
                for (int i = 0; i < input.Length-3; i++)
                {
                    if (input[i]=='+'&& input[i + 1] == '%' && input[i + 2] == '2' && input[i + 3] == '0')
                    {
                        input = input.Remove(i, 1);
                        i--;
                    }
                    else if (input[i]=='%'&&input[i+1]=='2'&&input[i+2]=='0'&&input[i+3]=='+')
                    {
                        input = input.Remove(i+3, 1);
                        i --;
                    }
                }
                input = input.Replace("+"," ");
                input = input.Replace("%20"," ");
               
                string[] arrInput = input.Split("&",StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in arrInput)
                {
                    if (regex.IsMatch(item))
                    {
                        string key = regex.Match(item).Groups[1].Value.Trim(' ');
                        string value= regex.Match(item).Groups[2].Value.Trim(' ');
                        if (dictMess.ContainsKey(key))
                        {
                            if (!dictMess[key].Contains(value))
                            {
                                dictMess[key].Add(value);
                            }
                        }
                        else
                        {
                            dictMess.Add(key, new List<string>());
                            dictMess[key].Add(value);
                        }
                    }
                }
                foreach (var item in dictMess)
                {
                    Console.Write($"{item.Key}=[");
                    Console.Write(string.Join(", ", item.Value));
                    Console.Write("]");
                }
                Console.WriteLine();
            }
            
        }
    }
}
