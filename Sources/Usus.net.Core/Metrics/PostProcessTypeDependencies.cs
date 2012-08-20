using andrena.Usus.net.Core.Metrics.Types;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class PostProcessTypeDependencies
    {
        public static void Of(MetricsReport metrics)
        {
            metrics.SetInterestingDirectDependencies();
            metrics.GraphOfTypes = CreateGraph.WithTypesOf(metrics);
            metrics.SetCumulativeComponentDependency();
        }

        private static void SetInterestingDirectDependencies(this MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
                type.InterestingDirectDependencies = InterestingDirectDependencies.Of(type, metrics.Types);
        }

        private static void SetCumulativeComponentDependency(this MetricsReport metrics)
        {
            foreach (var type in metrics.Types)
                type.CumulativeComponentDependency = CumulativeComponentDependency.Of(type, metrics.GraphOfTypes);
        }
    }
}
