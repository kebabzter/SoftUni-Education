using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List < Student > listStudent= new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] currentStudent = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = currentStudent[0];
                double[] grades = new double[currentStudent.Length-1];
                for (int j = 0; j < currentStudent.Length-1; j++)
                {
                    grades[j] = double.Parse(currentStudent[j+1]);
                }
                Student student = new Student(name,grades);
                if (student.AverageGrade>=5.00)
                {
                    listStudent.Add(student);
                }
            }
            foreach (var item in listStudent.OrderBy(x=>x.Name).ThenByDescending(x=>x.AverageGrade))
            {
                Console.WriteLine($"{item.Name} -> {item.AverageGrade:f2}");
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
        public double[] Grades { get; set; }
        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }

        public Student(string name, double[] grades)
        {
            Name = name;
            Grades = grades;
        }

    }
}
