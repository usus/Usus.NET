using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class GraphCyclesTest
    {
        [TestMethod]
        public void Cylces_StraightGraph_None()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var cycles = graphDict.GetCycles();
            Assert.AreEqual(0, cycles.Count(c => c.VertexCount > 1));
        }

        [TestMethod]
        public void Cylces_TwoVerticesInCycle_OneWithTwo()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { "a" });

            var cycles = graphDict.GetCycles();
            Assert.IsTrue(cycles.OfVertex("a").ContainsAllVertices("a", "b"));
            Assert.IsTrue(cycles.OfVertex("b").ContainsAllVertices("a", "b"));
        }

        [TestMethod]
        public void Cylces_FourVerticesTwoCycles_TwoWithTwo()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "a" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { "c" });

            var cycles = graphDict.GetCycles();

            Assert.IsTrue(cycles.OfVertex("a").ContainsAllVertices("a", "b"));
            Assert.IsTrue(cycles.OfVertex("b").ContainsAllVertices("a", "b"));
            Assert.IsTrue(cycles.OfVertex("c").ContainsAllVertices("c", "d"));
            Assert.IsTrue(cycles.OfVertex("d").ContainsAllVertices("c", "d"));
        }
    }
}
