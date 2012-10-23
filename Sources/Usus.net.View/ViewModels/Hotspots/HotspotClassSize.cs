using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotClassSize : TypeHotspot
    {
        public int Size { get { return Report.ClassSize; } }
        public string Class { get { return Report.Name; } }
        public string Fullname { get { return Report.FullName; } }
		public string Namespace { get { return Report.Namespaces.First(); } }

        public HotspotClassSize(TypeMetricsReport type, MetricsReport metrics)
            : base(type, metrics)
        {
        }
    }
}
