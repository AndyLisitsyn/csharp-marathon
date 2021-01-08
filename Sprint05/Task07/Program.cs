using System;
using System.Collections.Generic;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Student
    {
        public int Id { get; }
        public string Name { get; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public override bool Equals(object o)
        {
            return o is Student other && Id == other.Id && Name == other.Name;
        }

        public static HashSet<Student> GetCommonStudents(List<Student> list1, List<Student> list2)
        {
            var result = new HashSet<Student>(list1);
            result.IntersectWith(new HashSet<Student>(list2));
            return result;
        }
    }
}
