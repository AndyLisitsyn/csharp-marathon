using System;

namespace Question01
{
    class Program
    {
        static void Main(string[] args)
        {
            var v1 = new MyAccessModifiers(1991, "number", "info")
            {
                Name = "v1"
            };
            var v2 = new MyAccessModifiers(1991, "number", "info")
            {
                Name = "v1"
            };

            if (v1 == v2)
                Console.WriteLine("equal");
            else
                Console.WriteLine("not equal");
        }
    }
}
