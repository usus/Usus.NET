using System;
using System.Linq;
using System.Collections.Generic;
using QuickGraph;

namespace andrena.Usus.net.Core.Graphs
{
    internal static class BidirectionalGraphCloneExtensions
    {
        public static MutableGraph<R> Clone<T, R>(this BidirectionalGraph<T, Edge<T>> graph, Func<T, R> selector, Func<R, bool> condition)
            where R : class
        {
            var newGraph = BidirectionalGraphExtensions.NewGraph<R>(graph.AllowParallelEdges);
            var verticesMap = graph.CopyVertices<T, R>(newGraph, selector, condition);
            graph.CopyEdges<T, R>(newGraph, verticesMap);
            return new MutableGraph<R>(newGraph);
        }

        private static Dictionary<T, R> CopyVertices<T, R>(this BidirectionalGraph<T, Edge<T>> graph, BidirectionalGraph<R, Edge<R>> newGraph, Func<T, R> selector, Func<R, bool> condition)
            where R : class
        {
            var verticesMap = new Dictionary<T, R>();
            foreach (var vertex in graph.Vertices)
            {
                var newVertex = selector(vertex);
                if (condition(newVertex))
                {
                    verticesMap.Add(vertex, newVertex);
                    newGraph.AddVertex(newVertex);
                }
            }
            return verticesMap;
        }

        private static void CopyEdges<T, R>(this BidirectionalGraph<T, Edge<T>> graph, BidirectionalGraph<R, Edge<R>> newGraph, Dictionary<T, R> verticesMap)
            where R : class
        {
            foreach (Edge<T> edge in graph.Edges)
            {
                if (verticesMap.ContainsKey(edge.Source) && verticesMap.ContainsKey(edge.Target))
                {
                    var newEdge = new Edge<R>(verticesMap[edge.Source], verticesMap[edge.Target]);
                    newGraph.AddEdge(newEdge);
                }
            }
        }
    }
}
