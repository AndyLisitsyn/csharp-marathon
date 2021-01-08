using System;
using System.Linq;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "one two three four five six xxxaseven eight";
            Console.WriteLine(GetWord(str, "seed"));
        }

        public static string GetWord(string input, string seed)
        {
            return new string(input.Split(' ')
                .Aggregate(seed, (longest, next) => next.Length > longest.Length ? next : longest)
                .SkipWhile(x => x != 'a').ToArray());
        }
    }
}
