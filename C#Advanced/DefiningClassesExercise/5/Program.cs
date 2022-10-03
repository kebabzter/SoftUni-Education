using System;

namespace DateModifier
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            int diff = DateModifier.GetDiff(firstDate, secondDate);
            Console.WriteLine(diff);

        }
    }
}
