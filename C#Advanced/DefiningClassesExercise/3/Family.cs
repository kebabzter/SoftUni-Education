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

        public Person GetOldestMember()
        {
            return people.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
