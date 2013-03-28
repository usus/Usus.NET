using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageClassSizeTest
    {
        [TestMethod]
        public void Rate_0ClassSizes_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedClassSize());
        }

        [TestMethod]
        public void Rate_4ClassSizes_AverageRatedPoint0833()
        {
            Assert.AreEqual(0.0833, CreateAverage.RatedClassSize(5, 13, 15, 1), Constants.DELTA);
        }
    }
}
