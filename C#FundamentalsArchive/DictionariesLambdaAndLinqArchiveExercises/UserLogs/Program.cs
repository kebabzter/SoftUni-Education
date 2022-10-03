using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"IP=(.*) message=(.*) user=(.*)";
            Regex regex = new Regex(pattern);
            SortedDictionary<string, List<string>> userLog = new SortedDictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input!="end")
            {
                var match = regex.Match(input);
                string ip = match.Groups[1].Value;
                string user = match.Groups[3].Value;
                if (!userLog.ContainsKey(user))
                {
                    userLog.Add(user,new List<string>());
                }
                userLog[user].Add(ip);
                input = Console.ReadLine();
            }
            foreach (var item in userLog)
            {
                Console.WriteLine($"{item.Key}:");
                List<string> distinctIp = new List<string>();
                for (int i = 0; i < item.Value.Count; i++)
                {
                    if (!distinctIp.Contains(item.Value[i]))
                    {
                        distinctIp.Add(item.Value[i]);
                    }
                }
                for (int i = 0; i < distinctIp.Count; i++)
                {
                    if (i==distinctIp.Count-1)
                    {
                        Console.WriteLine($"{distinctIp[i]} => {item.Value.Count(x => x.Contains(distinctIp[i]))}.");
                    }
                    else
                    { 
                    Console.Write($"{distinctIp[i]} => {item.Value.Count(x => x.Contains(distinctIp[i]))}, ");
                    }
                }         
            }
        }
    }
}
