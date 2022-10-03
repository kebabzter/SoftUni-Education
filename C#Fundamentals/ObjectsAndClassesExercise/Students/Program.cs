using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> listStudents = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] currentStudent = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(currentStudent[0], currentStudent[1], double.Parse(currentStudent[2]));
                listStudents.Add(student);
            }
            var sortList = listStudents.OrderByDescending(x => x.Grade).ToList();
            foreach (var item in sortList)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName,string lastName,double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}
