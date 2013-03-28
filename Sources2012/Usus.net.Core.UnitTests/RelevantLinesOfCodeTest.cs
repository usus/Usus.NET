using andrena.Usus.net.Core.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RelevantLinesOfCodeTest
    {
        [TestMethod]
        public void Rloc_NoMethodNoTypes_0Lines()
        {
            var emptyMetrics = new MetricsReport();
            Assert.AreEqual(0, emptyMetrics.CommonKnowledge.RelevantLinesOfCode);
        }

        [TestMethod]
        public void Rloc_OneSingleLineMethodOneType_4Lines()
        {
            var metrics = Create.MetricsReport(Create.TypeMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, 1));
            Assert.AreEqual(4, metrics.CommonKnowledge.RelevantLinesOfCode);
        }

        [TestMethod]
        public void Rloc_TwoSingleLineMethodsOneType_6Lines()
        {
            var metrics = Create.MetricsReport(Create.TypeMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, 1, 1));
            Assert.AreEqual(6, metrics.CommonKnowledge.RelevantLinesOfCode);
        }

        [TestMethod]
        public void Rloc_TwoSingleLineMethodsTwoTypes_12Lines()
        {
            var metrics = Create.MetricsReport(
                Create.TypeMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, 1, 1), 
                Create.TypeMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, 1, 1));
            Assert.AreEqual(12, metrics.CommonKnowledge.RelevantLinesOfCode);
        }
    }
}
