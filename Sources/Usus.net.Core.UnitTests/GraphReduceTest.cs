using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class GraphReduceTest
    {
        [TestMethod]
        public void Reduce_TriangleGraph_SingleEdge()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var reduced = graphDict.GetReduced("ab", "a", "b");
            Assert.IsTrue(reduced.ContainsAllVertices("ab", "c"));
            Assert.IsTrue(reduced.ContainsAllVerticesNot("b"));
        }

        [TestMethod]
        public void Reduce_LineGraph_SingleVertex()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { });

            var reduced = graphDict.GetReduced("ab", "a", "b");
            Assert.IsTrue(reduced.ContainsAllVertices("ab"));
            Assert.IsTrue(reduced.ContainsAllVerticesNot("b"));
        }

        [TestMethod]
        public void Reduce_LineGraph_NoSelftEdge()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { });

            var reduced = graphDict.GetReduced("a'", "a");
            Assert.IsTrue(reduced.ContainsAllEdgesNot(Tuple.Create("b", "b")));
        }

        [TestMethod]
        public void Reduce_ParallelLinesGraph_ParallelsConnected()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { });

            var reduced = graphDict.GetReduced("ac", "a", "c");
            Assert.IsTrue(reduced.ContainsAllVertices("ac", "b", "d"));
            Assert.IsTrue(reduced.ContainsAllVerticesNot("c"));
            Assert.IsTrue(reduced.ContainsAllEdges(Tuple.Create("ac", "b"), Tuple.Create("ac", "d")));
        }

        [TestMethod]
        public void Reduce_FourVerticesWithInsAndOuts_ConnectedAllVerticesThere()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "e" });
            graphDict.Add("b", new List<string> { });
            graphDict.Add("c", new List<string> { });
            graphDict.Add("d", new List<string> { });
            graphDict.Add("e", new List<string> { });
            graphDict.Add("f", new List<string> { "d" });

            var reduced = graphDict.GetReduced("abcd", "a", "b", "c", "d");
            Assert.IsTrue(reduced.ContainsAllVertices("abcd", "e", "f"));
            Assert.IsTrue(reduced.ContainsAllVerticesNot("a", "b", "c", "d"));
        }

        [TestMethod]
        public void Reduce_FourVerticesWithInsAndOuts_ConnectedLine()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "e" });
            graphDict.Add("b", new List<string> { });
            graphDict.Add("c", new List<string> { });
            graphDict.Add("d", new List<string> { });
            graphDict.Add("e", new List<string> { });
            graphDict.Add("f", new List<string> { "d" });

            var reduced = graphDict.GetReduced("abcd", "a", "b", "c", "d");
            Assert.IsTrue(reduced.ContainsAllEdges(Tuple.Create("abcd", "e"), Tuple.Create("f", "abcd")));
        }

        [TestMethod]
        public void Reduce_GroupOfOneVertex_NothingChanged()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var reduced = graphDict.GetReduced("a'", "a");
            Assert.IsTrue(reduced.ContainsAllVertices("a'", "b", "c"));
            Assert.IsTrue(reduced.ContainsAllEdges(Tuple.Create("a'", "b"), Tuple.Create("a'", "c"), Tuple.Create("b", "c")));
        }

        [TestMethod]
        public void Reduce_GroupOfNoVertices_NothingChanged()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var reduced = graphDict.GetReduced("-");
            Assert.IsTrue(reduced.ContainsAllVertices("a", "b", "c"));
            Assert.IsTrue(reduced.ContainsAllEdges(Tuple.Create("a", "b"), Tuple.Create("a", "c"), Tuple.Create("b", "c")));
        }
    }
}
