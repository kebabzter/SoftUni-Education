using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (students.Count<Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName==lastName);
            if (student == null)
            {
                return "Student not found";
            }
            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            var result = students.Where(x => x.Subject == subject).ToList();
            if (result.Count>0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var item in result)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x=>x.FirstName==firstName&&x.LastName==lastName);
        }
    }
}
