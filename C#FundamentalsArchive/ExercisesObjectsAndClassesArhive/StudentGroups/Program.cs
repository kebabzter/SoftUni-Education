using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StudentGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> listTown = new List<Town>();
            int index = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="End")
                {
                    break;
                }
                if (input.Contains("=>"))
                {
                    string[] townArr = input.Split("=>",StringSplitOptions.RemoveEmptyEntries);
                    Town town = new Town();
                    town.Name = townArr[0];
                    string[] seats = townArr[1].Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    town.SeatsCount = int.Parse(seats[0]);
                    town.listStudents = new List<Student>();
                    listTown.Add(town);
                    index = listTown.IndexOf(town);
                }
                else
                {
                    Student student = new Student();
                    string[] studentArr = input.Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    student.Name = studentArr[0] + " " + studentArr[1];
                    student.Email = studentArr[2];
                    if (studentArr[2].Contains("|"))
                    {
                        student.Email = student.Email.Substring(1, studentArr[2].Length - 1);
                    }
                    if (studentArr[3].Contains("|"))
                    {
                        studentArr[3] = studentArr[3].Substring(1, studentArr[3].Length - 1);
                    }
                    student.RegDate= DateTime.ParseExact(studentArr[3], "d-MMM-yyyy", CultureInfo.InvariantCulture);
                    listTown[index].listStudents.Add(student);
                }
            }
            List <Group> groups= new List<Group>();
            foreach (var item in listTown.OrderBy(x=>x.Name))
            {
                IEnumerable<Student> students =
                item.listStudents.OrderBy(x => x.RegDate).ThenBy(n => n.Name).ThenBy(e => e.Email);

                while (students.Any())
                {
                    var group = new Group();
                    group.Town = item;
                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }
            Console.WriteLine($"Created {groups.Count} groups in {groups.Select(a => a.Town).Distinct().ToList().Count} towns:");

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Town.Name}=> {string.Join(", ", group.Students.Select(a => a.Email).ToList())}");
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
    }
    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> listStudents { get; set; }
    }
    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}
