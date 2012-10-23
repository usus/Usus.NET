using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotCumulativeComponentDependency : TypeHotspot
    {
        public int Dependencies { get { return Report.CumulativeComponentDependency; } }
        public string Class { get { return Report.Name; } }
        public string Fullname { get { return Report.FullName; } }
		public string Namespace { get { return Report.Namespaces.First(); } }

        public HotspotCumulativeComponentDependency(TypeMetricsReport type, MetricsReport metrics)
            : base(type, metrics)
        {
        }
    }
}
