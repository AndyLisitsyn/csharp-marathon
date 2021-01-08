using System.Collections.Generic;
using System.Linq;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static Lookup<string, string> CreateNotebook(Dictionary<string, string> phonesToNames) =>
            (Lookup<string, string>)phonesToNames.ToLookup(p => p.Value ?? string.Empty, p => p.Key);
    }
}
