using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics.Namespaces
{
    internal static class CyclicDependencies
    {
        public static StronglyConntectedComponents<NamespaceMetricsWithTypeMetrics> In(MutableGraph<NamespaceMetricsWithTypeMetrics> graph)
        {
            return graph.Cycles();
        }

        public static IEnumerable<string> Of(NamespaceMetricsWithTypeMetrics namespaceWithTypes, StronglyConntectedComponents<NamespaceMetricsWithTypeMetrics> cycles)
        {
            return namespaceWithTypes.GetOtherNamespacesInSameCycleIn(cycles).ToList(n => n.Name);
        }

        private static IEnumerable<NamespaceMetricsReport> GetOtherNamespacesInSameCycleIn(this NamespaceMetricsWithTypeMetrics namespaceWithTypes, StronglyConntectedComponents<NamespaceMetricsWithTypeMetrics> cycles)
        {
            return from n in cycles.OfVertex(namespaceWithTypes).Vertices
                   select n.Itself;
        }
    }
}