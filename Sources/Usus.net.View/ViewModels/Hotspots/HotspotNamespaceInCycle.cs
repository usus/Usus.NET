using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotNamespaceInCycle : NamespaceHotspot
    {
        public int CycleSize { get { return Report.NumberOfNamespacesInCycle; } }
        public string Namespace { get { return Report.Name; } }

        public HotspotNamespaceInCycle(NamespaceMetricsReport namespaceReport, MetricsReport metrics)
            : base(namespaceReport, metrics)
        {
        }
    }
}
