using System;
using System.Reflection;
using System.Linq;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(SomeClass);
            WriteAllInClass(t);
        }

        public static void WriteAllInClass(Type type)
        {
            var fields = type.GetFields();
            Console.WriteLine($"Hello, {type.Name}!");
            Console.WriteLine($"There are {fields.Length} fields in {type.Name}:");
            foreach (var f in fields)
                Console.Write(f.Name + ", ");
            Console.WriteLine();

            var properties = type.GetProperties();
            Console.WriteLine($"There are {properties.Length} properties in {type.Name}:");
            foreach (var p in properties)
                Console.Write(p.Name + ", ");
            Console.WriteLine();

            var methods = type.GetMethods(BindingFlags.DeclaredOnly |
                                        BindingFlags.Public |
                                        BindingFlags.Static)
                                        .Where(m => !m.IsSpecialName);

            Console.WriteLine($"There are {methods.Count()} methods in {type.Name}:");
            foreach (var m in methods)
                    Console.Write(m.Name + ", ");
            Console.WriteLine();

            var interfaces = type.GetNestedTypes().Where(nt => nt.IsInterface);
            Console.WriteLine($"There are {interfaces.Count()} interfaces in {type.Name}:");
            foreach (var i in interfaces)
                Console.Write(i.Name + ", ");
        }
    }

    class SomeClass
    {
        protected static int Property { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Doing domething...");
        }

        public interface SomeInterface
        {
            public void DoSomething();
        }
    }
}
