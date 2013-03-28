using System.Linq;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class CreateGraph
    {
        public static MutableGraph<TypeMetricsReport> WithTypesOf(MetricsReport metrics)
        {
            return metrics.Types
                .ToDictionary(t => t, t => t.InterestingDirectDependencies.Select(d => metrics.TypeForName(d)))
                .ToGraph();
        }

        public static MutableGraph<NamespaceMetricsWithTypeMetrics> WithNamespacesOf(MetricsReport metrics)
        {
            var namespaceGraph = metrics.GraphOfTypes.Cast(t => t.AsNamespaceWithTypes(), n => n.HasName);
            foreach (var namespaceGroup in namespaceGraph.Vertices.GroupBy(n => n.Itself.Name))
                namespaceGraph.Reduce(namespaceGroup.AsNamespaceWithTypes(), namespaceGroup);
            return namespaceGraph;
        }

        private static NamespaceMetricsWithTypeMetrics AsNamespaceWithTypes(this IGrouping<string, NamespaceMetricsWithTypeMetrics> namespaceGroup)
        {
            var namespaceWithTypes = new NamespaceMetricsWithTypeMetrics();
            namespaceWithTypes.Itself = new NamespaceMetricsReport { Name = namespaceGroup.Key };
            namespaceWithTypes.AddTypeReports(namespaceGroup);
            return namespaceWithTypes;
        }

        private static NamespaceMetricsWithTypeMetrics AsNamespaceWithTypes(this TypeMetricsReport t)
        {
            var namespaceWithTypes = new NamespaceMetricsWithTypeMetrics();
            namespaceWithTypes.Itself = new NamespaceMetricsReport { Name = t.Namespaces.FirstOrDefault() };
            namespaceWithTypes.AddTypeReport(t);
            return namespaceWithTypes;
        }
    }
}
