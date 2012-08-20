using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Graphs
{
    internal class GraphSurrogate<V, R> : IGraph<V>
        where V : class
        where R : class
    {
        IGraph<R> graph;
        Func<R, V> vertexSelector;

        internal GraphSurrogate(IGraph<R> graph, Func<R, V> vertexSelector)
        {
            this.graph = graph;
            this.vertexSelector = vertexSelector;
        }

        public IEnumerable<V> Vertices
        {
            get { return graph.Vertices.Select(vertexSelector); }
        }

        public IEnumerable<Tuple<V, V>> Edges
        {
            get { return graph.Edges.Select(e => Tuple.Create(vertexSelector(e.Item1), vertexSelector(e.Item2))); }
        }
    }
}
