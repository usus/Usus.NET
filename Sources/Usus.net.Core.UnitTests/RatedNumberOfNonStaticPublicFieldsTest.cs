using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedNumberOfNonStaticPublicFieldsTest
    {
        [TestMethod]
        public void Rate_NumberOfNonStaticPublicFields0_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.NumberOfNonStaticPublicFields(0));
        }
        
        [TestMethod]
        public void Rate_NumberOfNonStaticPublicFields1_Rated1()
        {
            Assert.AreEqual(1.0, CreateRated.NumberOfNonStaticPublicFields(1), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_NumberOfNonStaticPublicFields3_Rated1()
        {
            Assert.AreEqual(1.0, CreateRated.NumberOfNonStaticPublicFields(3), Constants.DELTA);
        }
    }
}
