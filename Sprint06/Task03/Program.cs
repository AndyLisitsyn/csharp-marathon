using System;
using System.Collections;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (float item in ShowPower.SuperPower(3, 0))
                Console.WriteLine(item);
        }
    }

    class ShowPower
    {
        public static IEnumerable SuperPower(int num, int degree)
        {
            float result = 1;

            if (degree == 0)
            {
                yield return result;
            }
            else if (degree > 0)
            {
                for (int i = 0; i < degree; i++)
                {
                    result *= num;
                    yield return result;
                }
            }
            else if (degree < 0)
            {
                if (num == 0) yield break;
                for (int i = 0; i < degree * -1; i++)
                {
                    result /= num;
                    yield return result;
                }
            }
        }
    }
}
