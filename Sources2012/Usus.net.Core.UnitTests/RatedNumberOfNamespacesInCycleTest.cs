using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedNumberOfNamespacesInCycleTest
    {
        [TestMethod]
        public void Rate_NumberOfNamespacesInCycle0_RatedFalse()
        {
            Assert.IsFalse(CreateRated.NumberOfNamespacesInCycle(0));
        }
     
        [TestMethod]
        public void Rate_NumberOfNamespacesInCycle1_RatedFalse()
        {
            Assert.IsFalse(CreateRated.NumberOfNamespacesInCycle(1));
        }
     
        [TestMethod]
        public void Rate_NumberOfNamespacesInCycle2_RatedTrue()
        {
            Assert.IsTrue(CreateRated.NumberOfNamespacesInCycle(2));
        }
    }
}
