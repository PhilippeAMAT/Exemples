
namespace Travel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static void Randomize<T>(this IEnumerable<T> target)
        {
            Random r = new Random();

            target = target.OrderBy(x => (r.Next()));
        }  
    }
}
