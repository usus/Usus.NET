using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{

    [TestClass]
    public class HotspotCyclomaticComplexityTest
    {
        [TestMethod]
        public void Hotspots_3CyclomaticComplexities1OverLimit_1Hotspot()
        {
            var hotspots = CreateHotspotOf.CyclomaticComplexity(2, 4, 5);
            Assert.IsTrue(hotspots.Count() == 1);
        }

        [TestMethod]
        public void Hotspots_3CyclomaticComplexities1OverCustomLimit_1Hotspot()
        {
            var hotspots = CreateHotspotOf.CyclomaticComplexityUnderLimit(5, 5, 6);
            Assert.IsTrue(hotspots.Count() == 1);
        }

        [TestMethod]
        public void Hotspots_3CyclomaticComplexitiesNoOverLimit_NoHotspot()
        {
            var hotspots = CreateHotspotOf.CyclomaticComplexity(2, 4, 4);
            Assert.IsTrue(hotspots.Count() == 0);
        }

        [TestMethod]
        public void Hotspots_NoCyclomaticComplexities_NoHotspot()
        {
            var hotspots = CreateHotspotOf.CyclomaticComplexity();
            Assert.IsTrue(hotspots.Count() == 0);
        }
    }
}
