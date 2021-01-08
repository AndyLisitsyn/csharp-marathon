using System;
using System.Reflection;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteProperties();
        }

        public static void WriteProperties()
        {
            Type t = typeof(TestProperties);
            var pi = t.GetProperties(BindingFlags.Public |
                                    BindingFlags.NonPublic |
                                    BindingFlags.Instance);
            Console.WriteLine(pi.Length);
            foreach (var p in pi)
                Console.WriteLine($"Property name: {p.Name}" +
                                    $"\nProperty type: {p.PropertyType.Name}" +
                                    $"\nRead-Write:    {p.CanRead && p.CanWrite}" +
                                    $"\nAccessibility: {GetAccessModifier(p.GetMethod)}");
        }

        public static string GetAccessModifier(MethodInfo mi)
        {
            if (mi.IsPrivate)
                return "Private";
            if (mi.IsFamily)
                return "Protected";
            if (mi.IsFamilyOrAssembly)
                return "Protected Internal";
            if (mi.IsAssembly)
                return "Internal";
            if (mi.IsPublic)
                return "Public";
            if (mi.IsFamilyAndAssembly)
                return "Private Protected";

            return string.Empty;
        }
    }

    public class TestProperties
    {
        public string FirstName { get; set; }
        internal string LastName { get; set; }
        protected int Age { get; set; }
        private string PhoneNumber { get; set; }
        protected internal int X { get; set; }
        private protected int Y { get; set; }
    }
}
