using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KeyReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = @"^([a-zA-Z]*)[\\<|].{0,}[\\<|]([a-zA-Z]*)$";
            Regex regex = new Regex(pattern);
            StringBuilder sb = new StringBuilder();
            if (regex.IsMatch(key))
            {
                string start = regex.Match(key).Groups[1].Value;
                string stop = regex.Match(key).Groups[2].Value;
                while (text.Contains(start) && text.Contains(stop))
                {
                    int indexStart = text.IndexOf(start) + start.Length;
                    int indexStop = text.IndexOf(stop);
                    if (indexStop>=indexStart)
                    {
                        string addStr = text.Substring(indexStart, indexStop - indexStart);
                        sb.Append(addStr);
                        text = text.Remove(0, indexStop + stop.Length);
                    }
                    else
                    {
                        string temp = text.Substring(indexStop + stop.Length);
                        if (temp.Contains(stop))
                        {
                            int indexTemp = temp.IndexOf(stop);
                            string addString = text.Substring(indexStart, indexStop + stop.Length + indexTemp - indexStart);
                            sb.Append(addString);
                            text = text.Remove(0, indexStop + stop.Length + indexTemp+stop.Length);
                        }
                    }
                   
                }
            }
            if (string.IsNullOrEmpty(sb.ToString()))
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(sb);
            }
        }
    }
}
