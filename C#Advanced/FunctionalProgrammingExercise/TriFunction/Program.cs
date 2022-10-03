using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> validator = (name,value)=>name.ToCharArray()
            .Select(c=>(int)c).Sum()>=number;

            Func<string[], int, Func<string, int, bool>, string> nameFound = (collection, value, func) =>
                   collection.FirstOrDefault(name => func(name, value));

            Console.WriteLine(nameFound(names,number,validator));
        }
    }
}
