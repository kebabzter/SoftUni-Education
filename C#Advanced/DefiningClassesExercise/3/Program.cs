using System;

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

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
