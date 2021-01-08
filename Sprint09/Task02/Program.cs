using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task02
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

    public static class CalcAsync
    {
        public static async Task TaskPrintSeqAsync(int n)
        {
            int y = await Task.Run(() => Calc.Seq(n));
            Console.WriteLine($"Seq[{n}] = {y}");
        }

        public static void PrintStatusIfChanged(this Task task, ref TaskStatus status)
        {
            if (task.Status != status)
            {
                Console.WriteLine(task.Status);
                status = task.Status;
            }
        }

        public static void TrackStatus(this Task task)
        {
            var status = new TaskStatus();
            while (status != TaskStatus.RanToCompletion)
                PrintStatusIfChanged(task, ref status);
        }
    }
}
