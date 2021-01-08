using System;
using System.Reflection;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void InvokeMethod(string[] strings)
        {
            Type t = typeof(Methods);
            MethodInfo[] mi = t.GetMethods(BindingFlags.Public |
                                            BindingFlags.Static |
                                            BindingFlags.DeclaredOnly);
            foreach (var m in mi)
                foreach (var s in strings)
                    m.Invoke(null, new object[] { s });
        }
    }

    public static class Methods
    {
        public static void Hello(string parameter) => Console.WriteLine("Hello:parameter={0}", parameter);
        public static void Welcome(string parameter) => Console.WriteLine("Welcome:parameter={0}", parameter);
        public static void Bye(string parameter) => Console.WriteLine("Bye:parameter={0}", parameter);
    }
}
