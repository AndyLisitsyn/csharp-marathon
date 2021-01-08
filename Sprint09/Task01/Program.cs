using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task01
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
        public static async void PrintSeqAsync(int n)
        {
            int y = await Task.Run(() => Calc.Seq(n));
            Console.WriteLine($"Seq[{n}] = {y}");
        }
    }
}
