using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageNumberOfNamespacesInCycleTest
    {
        [TestMethod]
        public void Rate_0NumberOfNamespacesInCycle_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedNumberOfNamespacesInCycle(), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_3NumberOfNamespacesInCycle_AverageRated0()
        {
            Assert.AreEqual(0.6667, CreateAverage.RatedNumberOfNamespacesInCycle(2, 2, 1), Constants.DELTA);
        }
    }
}
