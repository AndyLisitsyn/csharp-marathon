using System;
using System.Linq;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static double EvaluateAggregate(double[] inputData, Func<double, double, double> aggregate, Func<double, int, bool> predicate) =>
            inputData.Where(predicate).Aggregate(aggregate);
    }
}
