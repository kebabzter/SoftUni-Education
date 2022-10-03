using System;
using System.Collections.Generic;
using System.Linq;

namespace Students2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] studentInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentInfo[0], studentInfo[1], int.Parse(studentInfo[2]), studentInfo[3]);
                var studentExist = studentsList.FirstOrDefault(x=>x.FirstName==studentInfo[0]&&x.LastName==studentInfo[1]);
                if (studentExist==null)
                {
                    studentsList.Add(student);
                }
                else
                {
                    studentExist.Age = int.Parse(studentInfo[2]);
                    studentExist.Hometown = studentInfo[3];
                }
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
        public Student(string firstName, string lastName, int age, string hometown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Hometown = hometown;
        }

    }
}
