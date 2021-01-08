using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Calc
    {
        public static int Seq(int n)
        {
            Thread.Sleep(1000);
            return 1;
        }
    }

    class CalcAsync
    {
        public static async IAsyncEnumerable<(int, int)> SeqStreamAsync(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int y = await Task.Run(() => Calc.Seq(i));
                yield return (i, y);
            }
        }

        public static async void PrintStream(IAsyncEnumerable<(int, int)> stream)
        {
            await foreach (var tuple in stream)
                Console.WriteLine($"Seq[{tuple.Item1}] = {tuple.Item2}");
        }
    }
}
