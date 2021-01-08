using System;
using System.Threading;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class Buyer : PersonInTheShop
    {
        static Semaphore semaphore = new Semaphore(10, 10);
        Thread thread;

        public Buyer(string threadName)
        {
            thread = new Thread(Shop);
            thread.Name = threadName;
            thread.Start();
        }

        public void Shop()
        {
            semaphore.WaitOne();

            Enter();
            SelectGroceries();
            Pay();
            Leave();

            semaphore.Release();
        }
    }
}
