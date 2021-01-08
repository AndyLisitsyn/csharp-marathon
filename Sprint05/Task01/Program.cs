using System;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public static void TotalPrice(ILookup<string, Product> lookup)
        {
            foreach (IGrouping<string, Product> group in lookup)
            {
                decimal amount = 0;
                foreach (Product product in group)
                {
                    amount += product.Price;
                    Console.WriteLine($"{product.Name} {product.Price}");
                }
                Console.WriteLine($"{group.Key} {amount}");
            }
        }
    }
}




