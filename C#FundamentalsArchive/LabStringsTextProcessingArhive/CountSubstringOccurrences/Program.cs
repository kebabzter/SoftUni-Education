using System;
using System.Text;


namespace CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string searchString = Console.ReadLine().ToLower();
            int count = 0;
            char[] textSymbol = text.ToCharArray();
            int lengthSearch = searchString.Length;
            for (int i = 0; i < textSymbol.Length-lengthSearch+1; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j =i; j < i+lengthSearch; j++)
                {
                    sb.Append(textSymbol[j]);
                }
               
                if (searchString==sb.ToString())
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
