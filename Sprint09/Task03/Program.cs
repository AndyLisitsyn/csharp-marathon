using System;
using System.Threading;
using System.Threading.Tasks;


namespace Task03
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
        public static async Task<int> SeqAsync(int n)
        {
            return await Task.Run(() => Calc.Seq(n));
        }

        public static async void PrintSeqElementsConsequentlyAsync(int quant)
        {
            for (int i = 1; i <= quant; i++)
            {
                int y = await SeqAsync(i);
                Console.WriteLine($"Seq[{i}] = {y}");
            }
        }

        public static async void PrintSeqElementsInParallelAsync(int quant)
        {
            var tasks = GetSeqAsyncTasks(quant);
            await Task.WhenAll(tasks);
            for (int i = 1; i <= quant; i++)
                Console.WriteLine($"Seq[{i}] = {tasks[i - 1].Result}");
        }

        public static Task<int>[] GetSeqAsyncTasks(int quant)
        {
            var tasks = new Task<int>[quant];
            for (int i = 1; i <= quant; i++)
                tasks[i - 1] = SeqAsync(i);
            return tasks;
        }
    }
}
