using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedMethodLengthTest
    {
        [TestMethod]
        public void Rate_MethodLengthMinus1_Rated0()
        {
            Assert.AreEqual(0, CreateRated.MethodLength(-1));
        }

        [TestMethod]
        public void Rate_MethodLengthMinus1_FallbackToStatementsRatedPoint11()
        {
            Assert.AreEqual(0.11111111, CreateRated.MethodLength(-1, 10), Constants.DELTA);
        }

        [TestMethod]
        public void Rate_MethodLength0_Rated0()
        {
            Assert.AreEqual(0, CreateRated.MethodLength(0));
        }

        [TestMethod]
        public void Rate_MethodLength9_Rated0()
        {
            Assert.AreEqual(0, CreateRated.MethodLength(9));
        }

        [TestMethod]
        public void Rate_MethodLength10_RatedPoint11()
        {
            Assert.AreEqual(0.11111111, CreateRated.MethodLength(10), Constants.DELTA);
        }
    }
}
