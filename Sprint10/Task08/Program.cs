using System;

namespace Task08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    abstract class Invoice
    {
        public abstract double GetDiscount(double amount);
    }

    class FinalInvoice : Invoice
    {
        public override double GetDiscount(double amount) => amount - amount * 0.03;
    }

    class ProposedInvoice : Invoice
    {
        public override double GetDiscount(double amount) => amount - amount * 0.05;
    }

    class RecurringInvoice : Invoice
    {
        public override double GetDiscount(double amount) => amount - amount * 0.1;
    }

    class OrdinaryInvoice : Invoice
    {
        public override double GetDiscount(double amount) => amount - amount * 0.01;
    }
}
