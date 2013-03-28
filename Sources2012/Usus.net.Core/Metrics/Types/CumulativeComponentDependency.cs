using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class CumulativeComponentDependency
    {
        public static int Of(TypeMetricsReport type, MutableGraph<TypeMetricsReport> graph)
        {
            return type.GetDirectAndIndirectDependencies(graph)
                .Count(t => !t.CompilerGenerated);
        }

        private static IEnumerable<TypeMetricsReport> GetDirectAndIndirectDependencies(this TypeMetricsReport type, MutableGraph<TypeMetricsReport> graph)
        {
            return graph.Reach(type).Vertices;
        }
    }
}
