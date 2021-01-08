using System;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = { 1.1, 3.4, 2.2, 5.3, 0 };
            Console.WriteLine(EvaluateSumOfElementsOddPositions(a));
        }

        public static double EvaluateSumOfElementsOddPositions(double[] inputData) =>
            inputData.Where((num, idx) => idx % 2 != 0).Sum();
    }
}
