using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class GraphReachTest
    {
        [TestMethod]
        public void Reach_CircleGraph_All()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "d" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { "a" });

            var reach = graphDict.GetReach("a");
            Assert.IsTrue(reach.ContainsAllVertices("a", "b", "c", "d"));
        }

        [TestMethod]
        public void Reach_LineGraphFromLast_OnlyLastVertexReched()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { });

            var reach = graphDict.GetReach("d");
            Assert.IsTrue(reach.ContainsAllVerticesNot("a", "b", "c"));
            Assert.IsTrue(reach.ContainsAllVertices("d"));
        }

        [TestMethod]
        public void Reach_LineGraphFromSecondLast_LastTwoVerticesReached()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { "d" });
            graphDict.Add("d", new List<string> { });

            var reach = graphDict.GetReach("c");
            Assert.IsTrue(reach.ContainsAllVerticesNot("a", "b"));
            Assert.IsTrue(reach.ContainsAllVertices("c", "d"));
        }
    }
}
