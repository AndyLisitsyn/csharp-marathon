using System;
using System.Reflection;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteAssemblies();
        }

        public static void WriteAssemblies()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            foreach (var t in types)
            {
                if (t.Name == "Task" || t.Name == "Reflector") continue;
                var type = t.IsClass ? "Class" : "Interface";
                Console.WriteLine($"{type}: {t.Name}");
                var mi = t.GetMethods(BindingFlags.DeclaredOnly |
                                    BindingFlags.Public |
                                    BindingFlags.Static);
                foreach (var m in mi)
                {
                    Console.WriteLine($"Method: {m.Name}");
                    if (t.Name == "LargeBox")
                        m.Invoke(null, new object[] { "large" });
                    else if (t.Name == "SmallBox")
                        m.Invoke(null, new object[] { "small" });
                    else if (t.Name == "Box")
                        m.Invoke(null, new object[] { "middle" });
                }
            }
        }
    }

    public class LargeBox
    {
        public static void UnPackingBox(string size) => Console.WriteLine($"I am unpacking {size} box.");
        public static void InBox(string size) => Console.WriteLine($"I am in {size} box.");
    }

    public class Box
    {
        public static void UnPackingBox(string size) => Console.WriteLine($"I am unpacking {size} box.");
        public static void InBox(string size) => Console.WriteLine($"I am in {size} box.");
    }

    public class SmallBox
    {
        public static void UnPackingBox(string size) => Console.WriteLine($"I am unpacking {size} box.");
        public static void InBox(string size) => Console.WriteLine($"I am in {size} box.");
    }

    public interface ILookingForBox
    {
        static void LookForBox(string parameter) { }
    }

    public interface IPackingBox
    {
        static void PackBox(string parameter) { }
    }
}
