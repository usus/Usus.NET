using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class GraphCastTest
    {
        [TestMethod]
        public void Cast_EmptyGraph_EmptyGraph()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();

            var reduced = graphDict.GetCasted(v => v + "'");
            Assert.IsTrue(reduced.ContainsNoVertices());
            Assert.IsTrue(reduced.ContainsNoEdges());
        }

        [TestMethod]
        public void Cast_SimpleGraph_VerticesExtended()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var reduced = graphDict.GetCasted(v => v + "'");
            Assert.IsTrue(reduced.ContainsAllVertices("a'", "b'", "c'"));
        }

        [TestMethod]
        public void Cast_SimpleGraph_EdgesBetweenVertices()
        {
            var graphDict = new Dictionary<string, IEnumerable<string>>();
            graphDict.Add("a", new List<string> { "b", "c" });
            graphDict.Add("b", new List<string> { "c" });
            graphDict.Add("c", new List<string> { });

            var reduced = graphDict.GetCasted(v => v + "'");
            Assert.IsTrue(reduced.ContainsAllEdges(Tuple.Create("a'", "b'"), Tuple.Create("a'", "c'"), Tuple.Create("b'", "c'")));
        }
    }
}
