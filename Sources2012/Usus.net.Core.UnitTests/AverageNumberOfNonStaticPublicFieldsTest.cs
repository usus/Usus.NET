using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageNumberOfNonStaticPublicFieldsTest
    {
        [TestMethod]
        public void Rate_0NumberOfNonStaticPublicFields_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedNumberOfNonStaticPublicFields(), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_4NumberOfNonStaticPublicFields_AverageRatedPoint50()
        {
            Assert.AreEqual(0.50, CreateAverage.RatedNumberOfNonStaticPublicFields(2, 2, 0, 0), Constants.DELTA);
        }
    }
}
