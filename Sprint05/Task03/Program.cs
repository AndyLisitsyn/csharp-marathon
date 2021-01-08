using System;
using System.Collections.Generic;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void Position(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
                if (numbers[i] == 5)
                    Console.WriteLine(i + 1);
        }

        public static void Remove(List<int> numbers)
        {
            numbers.RemoveAll(n => n > 20);
            PrintList(numbers);
        }

        public static void Insert(List<int> numbers)
        {
            numbers.Insert(2, -5);
            numbers.Insert(5, -6);
            numbers.Insert(7, -7);
            PrintList(numbers);
        }

        public static void Sort(List<int> numbers)
        {
            numbers.Sort();
            PrintList(numbers);
        }

        static void PrintList(List<int> numbers)
        {
            foreach (int n in numbers)
                Console.WriteLine(n);
        }
    }
}
