using System;
using System.Reflection;
using System.Collections.Generic;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class ReflectFields
    {
        public static string Name;
        public static int MeasureX;
        public static int MeasureY;
        public static int MeasureZ;

        public static void OutputFields()
        {
            Type t = typeof(ReflectFields);
            FieldInfo[] fi = t.GetFields(BindingFlags.Public |
                                        BindingFlags.Static |
                                        BindingFlags.DeclaredOnly);
            foreach (var f in fi)
                Console.WriteLine($"{f.Name}" +
                    $" ({f.FieldType.Name switch {"String" => "string", "Int32" => "int", _ => f.FieldType.Name}})" +
                    $" = {f.GetValue(null)}");
        }
    }
}
