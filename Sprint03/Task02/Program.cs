using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!".WordCount());
        }
    }

    static class StringExtensions
    {
        public static int WordCount(this string text)
        {
            string[] delimiters = { " ", ".", ",", "?", "!", "..." };
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}
