using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<string> storePeople = new List<string>();
            string person = Console.ReadLine();
 
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
             
                if (input.Contains('-'))
                {
                    storePeople.Add(input);
                }
                else
                {
                    string[] info = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    string name = info[0] + " " + info[1];
                    string birthday = info[2];
                    Person newPerson = new Person(name, birthday);
                    people.Add(newPerson);
                }
            }

            foreach (var storePerson in storePeople)
            {
                Person parent;
                Person children;

                string[] info = storePerson.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                if (info[0].Contains('/') && info[1].Contains('/')) 
                {
                    string parentBirhtday = info[0];
                    string childrenBirthday = info[1];

                    parent = people.First(p => p.Birthday.Equals(parentBirhtday)); 
                    children = people.First(p => p.Birthday.Equals(childrenBirthday));
                }
                else if (info[0].Contains('/') || info[1].Contains('/')) 
                {
                    string name = string.Empty;
                    string birthday = string.Empty;

                    if (info[0].Contains('/')) 
                    {
                        birthday = info[0];
                        name = info[1];

                        parent = people.First(p => p.Birthday.Equals(birthday));
                        children = people.First(p => p.Name.Equals(name));
                    }
                    else 
                    {
                        birthday = info[1];
                        name = info[0];

                        children = people.First(p => p.Birthday.Equals(birthday));
                        parent = people.First(p => p.Name.Equals(name));
                    }
                }
                else
                {
                    var parentName = info[0];
                    var childrenName = info[1];

                    parent = people.First(p => p.Name.Equals(parentName));
                    children = people.First(p => p.Name.Equals(childrenName));
                }

                if (!parent.Children.Contains(children))
                {
                    parent.Children.Add(children);
                }

                if (!children.Parents.Contains(parent))
                {
                    children.Parents.Add(parent);
                }
            }

            Person ourPerson;
            if (person.Contains('/'))
            {
                ourPerson = people.First(p => p.Birthday.Equals(person));
            }
            else
            {
                ourPerson = people.First(p => p.Name.Equals(person));
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine(ourPerson.ToString());

            result.AppendLine("Parents:");
            foreach (var parent in ourPerson.Parents)
            {
                result.AppendLine(parent.ToString());
            }

            result.AppendLine("Children:");
            foreach (var child in ourPerson.Children)
            {
                result.AppendLine(child.ToString());
            }

            Console.Write(result);
        }
    }
    
}
