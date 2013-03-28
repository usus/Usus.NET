using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class HotspotNumberOfNonStaticPublicFieldsTest
    {
        [TestMethod]
        public void Hotspots_3NumberOfNonStaticPublicFields1OverLimit_1Hotspot()
        {
            var hotspots = CreateHotspotOf.NumberOfNonStaticPublicFields(0, 0, 1);
            Assert.IsTrue(hotspots.Count() == 1);
        }
     
        [TestMethod]
        public void Hotspots_3NumberOfNonStaticPublicFieldsNoOverLimit_NoHotspot()
        {
            var hotspots = CreateHotspotOf.NumberOfNonStaticPublicFields(0, 0, 0);
            Assert.IsTrue(hotspots.Count() == 0);
        }
        
        [TestMethod]
        public void Hotspots_NoNumberOfNonStaticPublicFields_NoHotspot()
        {
            var hotspots = CreateHotspotOf.NumberOfNonStaticPublicFields();
            Assert.IsTrue(hotspots.Count() == 0);
        }
    }
}
