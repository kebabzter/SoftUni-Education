using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] currentMember = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = new Person(currentMember[0],int.Parse(currentMember[1]));
                family.AddMember(currentPerson);
            }

            var filter = family.GetMembers().OrderBy(x => x.Name);
            foreach (var item in filter)
            {
                Console.WriteLine(item);
            }
        }
    }
}
