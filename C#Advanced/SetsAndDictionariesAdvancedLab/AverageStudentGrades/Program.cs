using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                decimal grade = decimal.Parse(info[1]);
                if (!students.ContainsKey(name))
                {
                    students.Add(name,new List<decimal>());
                }
                students[name].Add(grade);
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value.Select(x=>x.ToString("f2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
