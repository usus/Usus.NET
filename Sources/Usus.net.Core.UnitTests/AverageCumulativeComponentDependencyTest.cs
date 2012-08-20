using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageCumulativeComponentDependencyTest
    {
        [TestMethod]
        public void Rate_0CumulativeComponentDependencies_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.CumulativeComponentDependency(), Constants.DELTA);
        }
        
        [TestMethod]
        public void Rate_4And3And3And3CumulativeComponentDependencies_RatedPoint8125()
        {
            Assert.AreEqual(0.8125, CreateAverage.CumulativeComponentDependency(4, 3, 3, 3), Constants.DELTA);
        }
    }
}
