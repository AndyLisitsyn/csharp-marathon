using System;
using System.Threading;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void Counter(int num)
        {
            var factorialThread = new Thread(new ParameterizedThreadStart(CalculateFactorial));
            var fibonacciThread = new Thread(new ParameterizedThreadStart(CalculateFibonacci));
            factorialThread.Start(num);
            factorialThread.Join();
            fibonacciThread.Start(num);
        }

        static void CalculateFactorial(object obj)
        {
            int num = (int)obj;
            int result = 1;
            for (int i = 1; i <= num; i++)
                result *= i;
            Console.WriteLine($"Factorial is: {result}");
        }

        static void CalculateFibonacci(object obj)
        {
            int num = (int)obj;
            int fibo = GetFibonacci(num);
            Console.WriteLine($"Fibbonaci number is: {fibo}");
        }

        static int GetFibonacci(int num)
        {
            if (num == 0 || num == 1)
                return num;
            else
                return GetFibonacci(num - 1) + GetFibonacci(num - 2);
        }
    }
}
