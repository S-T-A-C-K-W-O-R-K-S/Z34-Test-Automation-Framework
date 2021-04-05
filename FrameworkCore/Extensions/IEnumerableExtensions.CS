using System;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkCore.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool None<TSource>(this IEnumerable<TSource> source)
        {
            return !source.Any();
        }

        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return !source.Any(predicate);
        }
    }
}