using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Helper
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Return<T>(this T start)
        {
            yield return start;
        }

        public static IEnumerable<T> ExceptThis<T>(this IEnumerable<T> sequence, T that)
        {
            return sequence.Except(that.Return());
        }

        public static List<R> ToList<T, R>(this IEnumerable<T> sequence, Func<T, R> selector)
        {
            return sequence.ToList(selector, t => true);
        }

        public static List<R> ToList<T, R>(this IEnumerable<T> sequence, Func<T, R> selector, Func<T, bool> condition)
        {
            return sequence.Where(condition).Select(selector).ToList();
        }

        public static double AverageAny<T>(this IEnumerable<T> sequence, Func<T, double> selector)
        {
            return sequence.AverageAny(selector, t => true);
        }

        public static double AverageAny<T>(this IEnumerable<T> sequence, Func<T, double> selector, Func<T, bool> condition)
        {
            return sequence.Where(condition).Any() ? sequence.Where(condition).Average(selector) : 0.0;
        }

        public static int CountAny<T>(this IEnumerable<T> sequence, Func<T, bool> selector)
        {
            return sequence.Count(selector);
        }

        public static string Number<T>(this IEnumerable<T> sequence)
        {
            return sequence.Count().ToString();
        }

        public static IDictionary<R, List<T>> TurnAround<T, R>(this IDictionary<T, R> dictionary)
        {
            Dictionary<R, List<T>> turnedAround = new Dictionary<R, List<T>>();
            foreach (var vertex in dictionary)
            {
                if (!turnedAround.ContainsKey(vertex.Value)) turnedAround.Add(vertex.Value, new List<T>());
                turnedAround[vertex.Value].Add(vertex.Key);
            }
            return turnedAround;
        }

        public static T WithMin<T, R>(this IEnumerable<T> sequence, Func<T, R> selector)
            where T : class
            where R : IComparable
        {
            if (!sequence.Any())
                return null;
            else
                return sequence.Aggregate((a, c) => selector(a).CompareTo(selector(c)) < 0 ? a : c);
        }

        public static T WithMax<T, R>(this IEnumerable<T> sequence, Func<T, R> selector)
            where T : class
            where R : IComparable
        {
            if (!sequence.Any())
                return null;
            else
                return sequence.Aggregate((a, c) => selector(a).CompareTo(selector(c)) > 0 ? a : c);
        }
    }
}
