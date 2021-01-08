using System;

namespace Question03
{
    class Program
    {
        static void Main(string[] args)
        {
            var fr1 = new Fraction(20, -10);
            var fr2 = new Fraction(1, 2);
            var sum = fr1 + fr2;
            Console.WriteLine(sum);
        }
    }
}
