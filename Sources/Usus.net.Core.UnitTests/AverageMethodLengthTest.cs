using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageMethodLengthTest
    {
        [TestMethod]
        public void Rate_0MethodLengths_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedMethodLength(), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_1MethodLength10_AverageRatedPoint1111()
        {
            Assert.AreEqual(0.1111, CreateAverage.RatedMethodLength(10), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_31MethodLengths_AverageRatedPoint0143()
        {
            Assert.AreEqual(0.0148, CreateAverage.RatedMethodLength(
                13, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), Constants.DELTA);
        }
    }
}
