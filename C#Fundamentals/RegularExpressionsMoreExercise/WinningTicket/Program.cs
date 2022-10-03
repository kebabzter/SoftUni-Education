using System;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                 .Split(new char[] {',',' '},StringSplitOptions.RemoveEmptyEntries);
            Regex regex = new Regex(@"[$]{6,10}|[#]{6,10}|[@]{6,10}|[\^]{6,10}");
            foreach (var ticket in text)
            {
                if (ticket.Length!=20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                string first = ticket.Substring(0, 10);
                string second = ticket.Substring(10,10);
                var matchFirst = regex.Match(first);
                var matchSecond = regex.Match(second);
                if (!matchFirst.Success||!matchSecond.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }
                if (matchFirst.Success&&matchSecond.Success&&matchFirst.Value[0]==matchSecond.Value[0])
                {
                    if (Math.Min(regex.Match(first).Length, regex.Match(second).Length) == 10)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - 10{matchFirst.Value[0]} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(regex.Match(first).Length, regex.Match(second).Length)}{matchFirst.Value[0]}");
                    }
                }
            }
        }
    }
}
