using System;
using System.Collections.Generic;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers.ToString<int>());
            numbers.IncreaseWith(5);
            Console.WriteLine(numbers.ToString<int>());
        }
    }

    static class IListExtensions
    {
        public static void IncreaseWith(this IList<int> list, int increment)
        {
            for (int i = 0; i < list.Count; i++)
                list[i] += increment;
        }
    }

    static class IEnumerableExtensions
    {
        public static string ToString<T>(this IEnumerable<T> list)
        {
            string result = "[";

            foreach (var item in list)
            {
                result += item.ToString();
                result += ", ";
            }
            var lastCommaIndex = result.LastIndexOf(',');
            if (lastCommaIndex > 0) result = result.Remove(lastCommaIndex, 2);

            return result + "]";
        }
    }
}
