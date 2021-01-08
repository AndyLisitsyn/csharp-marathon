using System;
using System.Collections.Generic;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
 
        }

        public static void SearchKeys(Dictionary<string, string> persons)
        {
            foreach (string key in persons.Keys)
                Console.WriteLine(key);
        }

        public static void SearchValues(Dictionary<string, string> persons)
        {
            foreach (string value in persons.Values)
                Console.WriteLine(value);
        }

        public static void SearchAdmin(Dictionary<string, string> persons)
        {
            foreach (KeyValuePair<string, string> pair in persons)
                if (pair.Value == "Admin")
                    Console.WriteLine($"{pair.Key} {pair.Value}");
        }
    }
}
