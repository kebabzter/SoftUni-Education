using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private HashSet<Person> people;

        public Family()
        {
            people = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public HashSet<Person> GetMembers()
        {
            return people.Where(x=>x.Age>30).ToHashSet();
        }
    }
}
