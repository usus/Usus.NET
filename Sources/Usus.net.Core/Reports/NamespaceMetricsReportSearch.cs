
namespace andrena.Usus.net.Core.Reports
{
    public static class NamespaceMetricsReportSearch
    {
        public static NamespaceMetricsReport ForNamespace(this MetricsReport metrics, string namespaceName)
        {
            return metrics.NamespaceForName(namespaceName);
        }
    }
}
