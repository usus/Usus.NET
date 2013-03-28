using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageCyclomaticComplexityTest
    {
        [TestMethod]
        public void Rate_0CyclomaticComplexities_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedCyclomaticComplexity(), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_1CyclomaticComplexity5_AverageRatedPoint25()
        {
            Assert.AreEqual(0.25, CreateAverage.RatedCyclomaticComplexity(5), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_31CyclomaticComplexitiesOneWith5_AverageRatedPoint008()
        {
            Assert.AreEqual(0.008, CreateAverage.RatedCyclomaticComplexity(
                5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_31CyclomaticComplexitiesOneWith6_AverageRatedPoint016()
        {
            Assert.AreEqual(0.0161, CreateAverage.RatedCyclomaticComplexity(
                6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), Constants.DELTA);
        }
    }
}
