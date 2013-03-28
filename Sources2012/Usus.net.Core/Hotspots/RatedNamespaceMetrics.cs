using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedNamespaceMetrics
    {
        public string Name { get; private set; }

        public bool IsInCycle { get; private set; }

        public RatedNamespaceMetrics(NamespaceMetricsReport metrics)
        {
            Name = metrics.Name;
            IsInCycle = metrics.RateNumberOfNamespacesInCycle();
        }
    }
}
