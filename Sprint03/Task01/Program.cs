using System;

namespace Task01
{
    delegate double CalcDelegate(double a, double b, char sign);

    class Program
    {
        static void Main(string[] args)
        {
            var calcProgram = new CalcProgram();
            Console.WriteLine(calcProgram.funcCalc(2, 2, '+'));
        }
    }

    class CalcProgram
    {
        public CalcDelegate funcCalc = Calc;

        public static double Calc(double a, double b, char sign)
        {
            return sign switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => b == 0 ? 0 : a / b,
                _ => 0,
            };
        }
    }
}
