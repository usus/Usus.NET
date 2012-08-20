using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotNonStaticPublicFields : TypeHotspot
    {
        public int Count { get { return Report.NumberOfNonStaticPublicFields; } }
        public string Class { get { return Report.Name; } }
        public string Fullname { get { return Report.FullName; } }

        public HotspotNonStaticPublicFields(TypeMetricsReport type, MetricsReport metrics)
            : base(type, metrics)
        {
        }
    }
}
