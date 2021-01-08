using System.Collections.Generic;
using System.Linq;


namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static bool ListDictionaryCompare(List<string> list, Dictionary<string, string> dictionary)
        {
            //return new HashSet<string>(list).SetEquals(new HashSet<string>(dictionary.Values));
            return list.Distinct().SequenceEqual(dictionary.Values.Distinct());
        }
    }
}
