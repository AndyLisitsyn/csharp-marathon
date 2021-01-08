using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task05
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
        public static async void PrintSpecificSeqElementsAsync(int[] integers)
        {
            var tasks = new Task[integers.Length];
            Task whenAllTask = null;
            try
            {
                for (int i = 0; i < integers.Length; i++)
                {
                    int x = integers[i];
                    tasks[i] = Task.Run(() => Console.WriteLine($"Seq[{x}] = {Calc.Seq(x)}"));
                }
                whenAllTask = Task.WhenAll(tasks);
                await whenAllTask;
            }
            catch (Exception e)
            {
                foreach (var inx in whenAllTask.Exception.InnerExceptions)
                    Console.WriteLine("Inner exception: " + inx.Message);
            }
        }
    }
}
