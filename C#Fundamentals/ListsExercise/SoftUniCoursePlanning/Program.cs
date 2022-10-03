using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "course start")
                {
                    break;
                }

                string[] modifyCourse = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string command = modifyCourse[0];
                switch (command)
                {
                    case "Add":
                        string lessonTitle = modifyCourse[1];
                        if (!courses.Contains(lessonTitle))
                        {
                            courses.Add(lessonTitle);
                        }
                        break;
                    case "Insert":
                        string lessonTitleInsert = modifyCourse[1];
                        int indexInsert = int.Parse(modifyCourse[2]);
                        if (indexInsert >= 0 && indexInsert <= courses.Count - 1)
                        {
                            if (!courses.Contains(lessonTitleInsert))
                            {
                                courses.Insert(indexInsert, lessonTitleInsert);
                            }
                        }
                        break;
                    case "Remove":
                        string lessonTitleRemove = modifyCourse[1];
                        if (courses.Contains(lessonTitleRemove))
                        {
                            courses.Remove(lessonTitleRemove);
                            string exercises = lessonTitleRemove + "-Exercise";
                            if (courses.Contains(exercises))
                            {
                                courses.Remove(exercises);
                            }
                        }
                        break;
                    case "Swap":
                        string lessonTitleSwap1 = modifyCourse[1];
                        string lessonTitleSwap2 = modifyCourse[2];
                        string exerciseSwap1 = lessonTitleSwap1 + "-Exercise";
                        string exerciseSwap2 = lessonTitleSwap2 + "-Exercise";

                        if (courses.Contains(lessonTitleSwap1) && courses.Contains(lessonTitleSwap2))
                        {
                            if (courses.Contains(exerciseSwap1))
                            {
                                courses.Remove(exerciseSwap1);
                                int indexSwap2 = courses.IndexOf(lessonTitleSwap2);
                                if (indexSwap2 == courses.Count - 1)
                                {
                                    courses.Add(exerciseSwap1);
                                }
                                else
                                {
                                    courses.Insert(indexSwap2 + 1, exerciseSwap1);
                                }
                            }

                            if (courses.Contains(exerciseSwap2))
                            {
                                courses.Remove(exerciseSwap2);
                                int indexSwap1 = courses.IndexOf(lessonTitleSwap1);
                                if (indexSwap1 == courses.Count - 1)
                                {
                                    courses.Add(exerciseSwap2);
                                }
                                else
                                {
                                    courses.Insert(indexSwap1 + 1, exerciseSwap2);
                                }
                            }
                            int idxSwap1 = courses.IndexOf(lessonTitleSwap1);
                            int idxSwap2 = courses.IndexOf(lessonTitleSwap2);
                            courses[idxSwap1] = lessonTitleSwap2;
                            courses[idxSwap2] = lessonTitleSwap1;
                        }
                        break;
                    case "Exercise":
                        string exerciseTitle = modifyCourse[1];
                        string exercise = exerciseTitle + "-Exercise";
                        if (courses.Contains(exerciseTitle))
                        {
                            int indexLesson = courses.IndexOf(exerciseTitle);
                            if (!courses.Contains(exercise))
                            {
                                courses.Insert(indexLesson + 1, exercise);
                            }
                        }
                        else
                        {
                            courses.Add(exerciseTitle);
                            courses.Add(exercise);
                        }
                        break;
                }

            }
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }
    }
}
