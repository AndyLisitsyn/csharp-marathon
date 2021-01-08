using System;

namespace Question02
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point(1, 0);
            var p2 = new Point(2, 0);
            Console.WriteLine($"Distance between p1 and p2 is: {p1.Distance(p2)}.");

            var d = (double)p2;
            Console.WriteLine($"p2 to double is: {d}.");
        }
    }
}
