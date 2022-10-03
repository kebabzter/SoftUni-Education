using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string patern = @"(@[#]+)([A-Z][A-Za-z0-9]{4,}[A-Z])(@[#]+)";
            Regex regex = new Regex(patern);
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                var match = regex.Match(barcode);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                string text = match.Groups[2].Value;
                StringBuilder sb = new StringBuilder();
                bool flag = false;
                for (int j = 0; j < text.Length; j++)
                {
                    if (char.IsDigit(text[j]))
                    {
                        sb.Append(text[j].ToString());
                        flag = true;
                    }
                }
                if (flag)
                {
                    Console.WriteLine($"Product group: {sb}");
                }
                else
                {
                    Console.WriteLine("Product group: 00");
                }
            }
        }
    }
}
