using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Graphs;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateGraph
    {
        public static IGraph<string> GetReach(this Dictionary<string, IEnumerable<string>> graphDict, string start)
        {
            var graph = graphDict.ToGraph();
            return graph.Reach(start);
        }

        public static IGraph<string> GetReduced(this Dictionary<string, IEnumerable<string>> graphDict, string newReduced, params string[] toReduce)
        {
            var graph = graphDict.ToGraph();
            graph.Reduce(newReduced, toReduce);
            return graph;
        }

        public static IGraph<string> GetCasted(this Dictionary<string, IEnumerable<string>> graphDict, Func<string, string> selector)
        {
            var graph = graphDict.ToGraph();
            return graph.Cast(selector, n => true);
        }

        public static StronglyConntectedComponents<string> GetCycles(this Dictionary<string, IEnumerable<string>> graphDict)
        {
            var graph = graphDict.ToGraph();
            return graph.Cycles();
        }

        public static bool ContainsAllVertices(this StronglyConntectedComponent<string> cycle, params string[] others)
        {
            return cycle.VertexCount == others.Length && cycle.Vertices.All(c => others.Contains(c));
        }

        public static bool ContainsAllEdges(this IGraph<string> sequence, params Tuple<string, string>[] contains)
        {
            return contains.All(c => sequence.Edges.Contains(c));
        }

        public static bool ContainsAllEdgesNot(this IGraph<string> sequence, params Tuple<string, string>[] contains)
        {
            return contains.All(c => !sequence.Edges.Contains(c));
        }

        public static bool ContainsNoEdges(this IGraph<string> sequence)
        {
            return !sequence.Edges.Any();
        }

        public static bool ContainsAllVertices(this IGraph<string> sequence, params string[] contains)
        {
            return contains.All(c => sequence.Vertices.Contains(c));
        }

        public static bool ContainsAllVerticesNot(this IGraph<string> sequence, params string[] contains)
        {
            return contains.All(c => !sequence.Vertices.Contains(c));
        }

        public static bool ContainsNoVertices(this IGraph<string> sequence)
        {
            return !sequence.Vertices.Any();
        }
    }
}
