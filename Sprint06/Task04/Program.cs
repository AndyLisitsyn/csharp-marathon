using System;
using System.Collections;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Single item in ShowPowerRange.PowerRanger(0, 0, 200))
                Console.WriteLine(item);
        }
    }

    class ShowPowerRange
    {
        public static IEnumerable PowerRanger(int degree, int start, int finish)
        {
            if (start > finish || start < 0 || finish < 0)
            {
                yield break;
            }
            else if (degree == 0)
            {
                if (start <= 1)
                    yield return (Single)1;
                else
                    yield break;
            }
            else
            {
                int i = 0;
                double result;
                while (true)
                {
                    do
                    {
                        result = Math.Pow(i++, degree);
                    }
                    while (result < start);

                    if (result > finish)
                        yield break;
                    else
                        yield return (Single)result;
                }
            }
        }
    }
}
