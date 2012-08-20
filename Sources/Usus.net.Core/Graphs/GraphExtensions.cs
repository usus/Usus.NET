using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.Graphs
{
    public static class GraphExtensions
    {
        public static MutableGraph<V> ToGraph<V>(this IDictionary<V, IEnumerable<V>> graphDict)
            where V : class
        {
            return new MutableGraph<V>(graphDict);
        }

        public static IGraph<V> Select<V, R>(this IGraph<R> graph, Func<R, V> vertexSelector)
            where V : class
            where R : class
        {
            return new GraphSurrogate<V, R>(graph, vertexSelector);
        }
    }
}
