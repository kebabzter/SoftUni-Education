using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input=="end")
                {
                    break;
                }
                string[] studentInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentInfo[0],studentInfo[1],int.Parse(studentInfo[2]),studentInfo[3]);
                studentsList.Add(student);
            }

            string city = Console.ReadLine();
            var filterList = studentsList.Where(x => x.Hometown == city);
            foreach (var item in filterList)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
        public Student(string firstName,string lastName,int age,string hometown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Hometown = hometown;
        }

    }
}
