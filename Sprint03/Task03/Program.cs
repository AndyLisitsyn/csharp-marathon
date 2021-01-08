using System;
using System.Collections.Generic;

namespace Task03
{
    public delegate bool IsPositive(int element);

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, -2, 3, -4, 11 };
            var positiveList = ListWithPositive(list);
            foreach (var element in positiveList)
                Console.WriteLine(element);
        }

        public static List<int> ListWithPositive(List<int> list)
        {
            return list.FindAll(delegate (int n) { return n > 0 && n <= 10; });
        }
    }

    public static class ListExtensions
    {
        public static List<int> FindAll(this List<int> list, IsPositive predicate)
        {
            var positiveElements = new List<int>();

            foreach (var element in list)
                if (predicate(element))
                    positiveElements.Add(element);

            return positiveElements;
        }
    }
}
