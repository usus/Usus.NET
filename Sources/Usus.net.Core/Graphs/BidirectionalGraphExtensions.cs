using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Search;

namespace andrena.Usus.net.Core.Graphs
{
    internal static class BidirectionalGraphExtensions
    {
        public static BidirectionalGraph<T, Edge<T>> NewGraph<T>(bool parallelEdges)
        {
            return new BidirectionalGraph<T, Edge<T>>(parallelEdges);
        }

        public static BidirectionalGraph<T, Edge<T>> ToNewGraph<T>(this T start, bool parallelEdges)
        {
            var graph = NewGraph<T>(parallelEdges);
            graph.AddVertex(start);
            return graph;
        }

        public static void MergeVertices<T>(this BidirectionalGraph<T, Edge<T>> reducedGraph, T reducedVertex, IEnumerable<T> vertices)
        {
            reducedGraph.AddVertex(reducedVertex);
            foreach (var vertex in vertices)
            {
                reducedGraph.AddEdge(new Edge<T>(reducedVertex, vertex));
                reducedGraph.AddEdge(new Edge<T>(vertex, reducedVertex));
                reducedGraph.MergeVertex(vertex, (s, t) => new Edge<T>(s, t));
            }
        }

        public static void Dfs<T>(this BidirectionalGraph<T, Edge<T>> graph, T start, Action<Edge<T>> foundEdge)
        {
            var dfs = new DepthFirstSearchAlgorithm<T, Edge<T>>(graph);
            dfs.StartVertex += v => { if (!v.Equals(start)) dfs.Abort(); };
            dfs.ExamineEdge += e => foundEdge(e);
            dfs.Compute(start);
        }

        public static StronglyConntectedComponents<T> Sccs<T>(this BidirectionalGraph<T, Edge<T>> graph)
        {
            IDictionary<T, int> sccNumbering;
            graph.StronglyConnectedComponents(out sccNumbering);
            return new StronglyConntectedComponents<T>(sccNumbering, sccNumbering.TurnAround());
        }
    }
}
