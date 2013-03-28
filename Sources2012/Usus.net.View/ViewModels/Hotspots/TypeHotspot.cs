using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class TypeHotspot : Hotspot<TypeMetricsReport>
    {
        MetricsReport metrics;

        public TypeHotspot(TypeMetricsReport type, MetricsReport metrics)
            : base(type)
        {
            this.metrics = metrics;
        }

        public override void OnDoubleClick(IJumpToSource jumper)
        {
            TypeJump.To(metrics, Report, jumper);
        }
    }
}
