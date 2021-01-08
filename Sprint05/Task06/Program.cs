using System;
using System.Collections.Generic;
using System.Linq;

namespace Task06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static Dictionary<string, List<string>> ReverseNotebook(Dictionary<string, string> phonesToNames) =>
            phonesToNames.ToLookup(p => p.Value ?? string.Empty, p => p.Key).ToDictionary(g => g.Key, g => g.ToList());
    }
}
