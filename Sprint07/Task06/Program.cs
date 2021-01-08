using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static string CreateGroups(List<Student> students, List<Group> groups)
        {
            var query = groups.GroupJoin(
                                        students,
                                        g => g.Name,
                                        s => s.GroupName,
                                        (group, students) => new
                                        {
                                            group = group.Name,
                                            description = group.Description,
                                            rating = students.Count() == 0 ? 0 :
                                                students.Select(s => s.Rating).Sum() / students.Count(),
                                            students = students.Select(s => new
                                            {
                                                FullName = s.Name,
                                                AvgMark = s.Rating
                                            })
                                        });

            return JsonSerializer.Serialize(query, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    class Student
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string GroupName { get; set; }
    }

    class Group
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Popularity { get; set; }
    }
}
