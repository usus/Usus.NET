using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedClassSizeTest
    {
        [TestMethod]
        public void Rate_ClassSize0_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.ClassSize(0), Constants.DELTA);
        }
        
        [TestMethod]
        public void Rate_ClassSize12_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.ClassSize(12), Constants.DELTA);
        }
        
        [TestMethod]
        public void Rate_ClassSize13_RatedPoint0833()
        {
            Assert.AreEqual(0.0833, CreateRated.ClassSize(13), Constants.DELTA);
        }
    }
}
