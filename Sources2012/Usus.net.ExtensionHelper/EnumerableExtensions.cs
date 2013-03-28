using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.ExtensionHelper
{
    public static class EnumerableExtensions
    {
        public static T WithMin<T, R>(this IEnumerable<T> sequence, Func<T, R> selector) where R : IComparable
        {
            return sequence.Aggregate((a, c) => selector(a).CompareTo(selector(c)) < 0 ? a : c);
        }
     
        public static T WithMax<T, R>(this IEnumerable<T> sequence, Func<T, R> selector) where R : IComparable
        {
            return sequence.Aggregate((a, c) => selector(a).CompareTo(selector(c)) > 0 ? a : c);
        }
    }
}
