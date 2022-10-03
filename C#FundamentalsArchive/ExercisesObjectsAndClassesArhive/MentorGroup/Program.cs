using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Member> members = new List<Member>();
            while (input != "end of dates")
            {
                string[] attendancyData = input.Split(new char[] { ' ', ',' },
                                          StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = attendancyData[0].Trim();
                Member member = new Member();
                member.Name = name;
                member.AttendingDates = new List<DateTime>();
                member.Comments = new List<string>();
                for (int i = 1; i < attendancyData.Length; i++)
                {
                    DateTime date = DateTime.ParseExact(attendancyData[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (members.Any(m => m.Name == name))
                    {
                        Member currMember = members.Single(m => m.Name == name);
                        currMember.AttendingDates.Add(date);
                    }
                    else
                    {
                        member.AttendingDates.Add(date);
                        members.Add(member);
                    }
                }
                if (attendancyData.Length == 1 && !members.Any(m => m.Name == name))
                {
                    member.AttendingDates = new List<DateTime>();
                    members.Add(member);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of comments")
            {
                string[] commentsData = input.Split('-').ToArray();
                string name = commentsData[0];
                string comment = commentsData[1];

                if (members.Any(m => m.Name == name))
                {
                    Member currentMember = members.Single(m => m.Name == name);
                    currentMember.Comments.Add(comment);
                }
                input = Console.ReadLine();
            }
            foreach (var member in members.OrderBy(m => m.Name))
            {
                Console.WriteLine($"{member.Name}");
                Console.WriteLine("Comments:");
                foreach (var comment in member.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");
                foreach (var date in member.AttendingDates.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }
        }
    }
    class Member
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> AttendingDates { get; set; }


    }
}
