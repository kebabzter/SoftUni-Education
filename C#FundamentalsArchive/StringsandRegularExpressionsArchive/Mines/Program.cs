using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            string mines = Console.ReadLine();
            string pattern = @"(<..>)";
            Regex regex = new Regex(pattern);
            while (regex.IsMatch(mines))
            {
                var match = regex.Match(mines);
                char firstSymbol = char.Parse(match.ToString().Substring(1, 1));
                char secondSymbol = char.Parse(match.ToString().Substring(2,1));
                int power = Math.Abs((int)firstSymbol-(int)secondSymbol);
                int index = match.Index;
                StringBuilder sb = new StringBuilder();
                if (index<=power)
                {
                    for (int i = 0; i < index; i++)
                    {
                        sb.Append("_");
                    }
                }
                else
                {
                    sb.Append(mines.Substring(0,index-power));
                    for (int i = 0; i < power; i++)
                    {
                        sb.Append("_");
                    }
                }
                sb.Append("____");
                if (index+4+power>=mines.Length-1)
                {
                    for (int i = 0; i < mines.Length-index-4; i++)
                    {
                        sb.Append("_");
                    }
                }
                else
                {
                    for (int i = 0; i < power; i++)
                    {
                        sb.Append("_");
                    }
                    sb.Append(mines.Substring(index+4+power));
                }
                mines = sb.ToString();
            }
            Console.WriteLine(mines);
        }
    }
}
