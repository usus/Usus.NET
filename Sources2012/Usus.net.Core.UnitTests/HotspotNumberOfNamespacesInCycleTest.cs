using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class HotspotNumberOfNamespacesInCycleTest
    {
        [TestMethod]
        public void Hotspots_NoCyclicDependencies_NoHotspot()
        {
            var hotspots = CreateHotspotOf.NumberOfNamespacesInCycle();
            Assert.IsTrue(hotspots.Count() == 0);
        }

        [TestMethod]
        public void Hotspots_JustSingleNamespace_NoHotspots()
        {
            var hotspots = CreateHotspotOf.NumberOfNamespacesInCycle(1, 1, 1);
            Assert.IsTrue(hotspots.Count() == 0);
        }

        [TestMethod]
        public void Hotspots_TwoCyclicDependencies_TwoHotspots()
        {
            var hotspots = CreateHotspotOf.NumberOfNamespacesInCycle(2, 2);
            Assert.IsTrue(hotspots.Count() == 2);
        }

        [TestMethod]
        public void Hotspots_ThreeCyclicDependencies_ThreeHotspots()
        {
            var hotspots = CreateHotspotOf.NumberOfNamespacesInCycle(3, 3, 3);
            Assert.IsTrue(hotspots.Count() == 3);
        }
    }
}
