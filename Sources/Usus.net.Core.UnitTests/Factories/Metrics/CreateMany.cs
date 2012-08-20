using System;
using System.Linq;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories.Metrics
{
    public static class CreateMany
    {
        public static RatedMetrics RatedMetrics(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            return Metrics(methodMetricsReport, metrics).Rate();
        }

        public static RatedMetrics RatedMetrics(Func<int, TypeMetricsReport> typeMetricsReport, params int[] metrics)
        {
            return Metrics(typeMetricsReport, metrics).Rate();
        }

        public static RatedMetrics RatedMetrics(Func<int, NamespaceMetricsReport> namespaceMetricsReport, params int[] metrics)
        {
            return Metrics(namespaceMetricsReport, metrics).Rate();
        }

        public static MetricsReport Metrics(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            return Create.MetricsReport(from metric in metrics
                                        select methodMetricsReport(metric));
        }

        public static MetricsReport Metrics(Func<int, TypeMetricsReport> typeMetricsReport, params int[] metrics)
        {
            return Create.MetricsReport(from metric in metrics
                                        select typeMetricsReport(metric));
        }

        public static MetricsReport Metrics(Func<int, NamespaceMetricsReport> namespaceMetricsReport, params int[] metrics)
        {
            return Create.MetricsReport(from metric in metrics
                                        select namespaceMetricsReport(metric));
        }
    }
}
