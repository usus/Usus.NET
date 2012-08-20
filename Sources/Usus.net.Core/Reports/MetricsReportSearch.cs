using System.Collections.Generic;

namespace andrena.Usus.net.Core.Reports
{
    public static class MetricsReportSearch
    {
        public static IEnumerable<MethodMetricsReport> MethodsOfType(this MetricsReport metrics, TypeMetricsReport typeMetrics)
        {
            return metrics.MethodsOf(typeMetrics);
        }

        public static IEnumerable<TypeMetricsReport> TypesOfNamespace(this MetricsReport metrics, NamespaceMetricsReport namespaceMetrics)
        {
            return metrics.TypesOf(namespaceMetrics);
        }
    }
}
