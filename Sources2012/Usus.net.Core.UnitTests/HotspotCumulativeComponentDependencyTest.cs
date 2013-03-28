using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class HotspotCumulativeComponentDependencyTest
    {
        [TestMethod]
        public void Hotspots_4CumulativeComponentDependencies1OverLimit_1Hotspot()
        {
            var hotspots = CreateHotspotOf.CumulativeComponentDependency(4, 3, 2, 1);
            Assert.IsTrue(hotspots.Count() == 1);
        }

        [TestMethod]
        public void Hotspots_NoCumulativeComponentDependencies_NoHotspot()
        {
            var hotspots = CreateHotspotOf.CumulativeComponentDependency();
            Assert.IsTrue(hotspots.Count() == 0);
        }
    }
}
