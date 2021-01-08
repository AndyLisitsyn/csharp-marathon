using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class MainThreadProgram
    {
        public static void Sum()
        {
            int sum = 0;
            Console.WriteLine($"Enter the 1st number:");
            sum += Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Enter the 2nd number:");
            sum += Int32.Parse(Console.ReadLine());
            for (int i = 3; i <= 5; i++)
            {
                Console.WriteLine($"Enter the {i}th number:");
                sum += Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Sum is: {sum}");
        }

        public static void Product()
        {
            List<int> list = Enumerable.Range(1, 10).ToList();
            int product = list.Aggregate((item1, item2) => (item1 * item2));
            Thread.Sleep(10000);
            Console.WriteLine($"Product is: {product}");
        }

        public static (Thread, Thread) Calculator()
        {
            var productThread = new Thread(new ThreadStart(Product));
            var sumThread = new Thread(new ThreadStart(Sum));
            productThread.Start();
            sumThread.Start();

            return (sumThread, productThread);
        }
    }
}
