using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories.Metrics
{
    public static class Create
    {
        public static MetricsReport MetricsReport(IEnumerable<MethodMetricsReport> methodMetrics)
        {
            var metricsReport = new MetricsReport();
            metricsReport.AddTypeReport(TypeMetrics(new TypeMetricsReport() { FullName = RandomName() }, methodMetrics));
            return metricsReport;
        }

        public static MetricsReport MetricsReport(IEnumerable<TypeMetricsReport> typeMetrics)
        {
            var metricsReport = new MetricsReport();
            foreach (var typeMetric in typeMetrics)
                metricsReport.AddTypeReport(TypeMetrics(typeMetric, Enumerable.Empty<MethodMetricsReport>()));
            return metricsReport;
        }

        internal static MetricsReport MetricsReport(params TypeMetricsWithMethodMetrics[] typeMetrics)
        {
            var metricsReport = new MetricsReport();
            foreach (var typeMetric in typeMetrics)
                metricsReport.AddTypeReport(TypeMetrics(typeMetric.Itself, typeMetric.Methods));
            return metricsReport;
        }

        public static MetricsReport MetricsReport(IEnumerable<NamespaceMetricsReport> namespaceMetrics)
        {
            var metricsReport = new MetricsReport();
            foreach (var namespaceMetric in namespaceMetrics)
                metricsReport.AddNamespaceReport(NamespaceMetrics(namespaceMetric, Enumerable.Empty<TypeMetricsReport>()));
            return metricsReport;
        }

        internal static TypeMetricsWithMethodMetrics TypeMetrics(Func<int, MethodMetricsReport> methodMetricsReport, params int[] metrics)
        {
            return TypeMetrics(new TypeMetricsReport { FullName = RandomName() }, 
                from metric in metrics select methodMetricsReport(metric));
        }

        private static TypeMetricsWithMethodMetrics TypeMetrics(TypeMetricsReport typeMetrics, IEnumerable<MethodMetricsReport> methodMetrics)
        {
            var typeWithMethods = new TypeMetricsWithMethodMetrics() { Itself = typeMetrics };
            typeWithMethods.AddMethodReports(methodMetrics);
            return typeWithMethods;
        }

        private static NamespaceMetricsWithTypeMetrics NamespaceMetrics(NamespaceMetricsReport namespaceMetrics, IEnumerable<TypeMetricsReport> typeMetrics)
        {
            var namespaceWithTypes = new NamespaceMetricsWithTypeMetrics() { Itself = namespaceMetrics };
            foreach (var typeMetric in typeMetrics) namespaceWithTypes.AddTypeReport(typeMetric);
            return namespaceWithTypes;
        }

        static Random randomizer = new Random();
        internal static string RandomName()
        {
            return randomizer.NextDouble().ToString();
        }

        internal static IEnumerable<T> Default<T>(int count)
        {
            return Enumerable.Repeat(default(T), count);
        }
    }
}
