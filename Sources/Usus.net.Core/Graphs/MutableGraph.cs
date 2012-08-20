using System;
using System.Collections.Generic;
using System.Linq;
using QuickGraph;

namespace andrena.Usus.net.Core.Graphs
{
    public class MutableGraph<V> : IGraph<V> where V : class
    {
        BidirectionalGraph<V, Edge<V>> graph;
        const bool PARALLEL_EDGES = false;

        public IEnumerable<V> Vertices { get { return graph.Vertices; } }
        public IEnumerable<Tuple<V, V>> Edges { get { return graph.Edges.Select(e => Tuple.Create(e.Source, e.Target)); } }

        public MutableGraph(IDictionary<V, IEnumerable<V>> graphDict)
        {
            graph = graphDict.Keys.ToBidirectionalGraph(v => graphDict[v].Select(e => new Edge<V>(v, e)), PARALLEL_EDGES);
        }

        internal MutableGraph(BidirectionalGraph<V, Edge<V>> graph)
        {
            this.graph = graph;
        }

        public void Reduce(V vertex, IEnumerable<V> vertices)
        {
            graph.MergeVertices(vertex, vertices);
        }

        public MutableGraph<V> Reach(V start)
        {
            var reachGraph = start.ToNewGraph(PARALLEL_EDGES);
            graph.Dfs(start, e => reachGraph.AddVerticesAndEdge(e));
            return new MutableGraph<V>(reachGraph);
        }
        
        public MutableGraph<R> Cast<R>(Func<V, R> selector, Func<R, bool> condition) where R : class
        {
            return graph.Clone(selector, condition);
        }

        public StronglyConntectedComponents<V> Cycles()
        {
            return graph.Sccs();
        }
    }
}
