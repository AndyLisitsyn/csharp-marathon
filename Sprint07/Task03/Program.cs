using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static int ProductWithCondition(List<int> integers, Func<int, bool> predicate)
        {
            //var query = integers.Where(i => predicate(i));
            //return query.Count() == 0 ? 1 : query.Aggregate((i1, i2) => i1 * i2);
            return integers.Where(predicate).Aggregate(1, (i1, i2) => i1 * i2);
        }
    }
}
