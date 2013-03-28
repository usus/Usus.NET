using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories.Metrics
{
    public static class CreateAverage
    {
        public static double RatedCyclomaticComplexity(params int[] ccs)
        {
            return CreateMany.RatedMetrics(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .AverageRatedCyclomaticComplexity;
        }

        public static double RatedMethodLength(params int[] mls)
        {
            return CreateMany.RatedMetrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, mls)
                .AverageRatedMethodLength;
        }

        public static double RatedClassSize(params int[] css)
        {
            return CreateMany.RatedMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfMethods = m }, css)
                .AverageRatedClassSize;
        }

        public static double RatedNumberOfNonStaticPublicFields(params int[] nspfs)
        {
            return CreateMany.RatedMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfNonStaticPublicFields = m }, nspfs)
                .AverageRatedNumberOfNonStaticPublicFields;
        }

        public static double CumulativeComponentDependency(params int[] ccds)
        {
            return CreateMany.RatedMetrics(m => new TypeMetricsReport { FullName = Create.RandomName(), CumulativeComponentDependency = m }, ccds)
                .AverageComponentDependency;
        }

        public static double RatedNumberOfNamespacesInCycle(params int[] nonics)
        {
            return CreateMany.RatedMetrics(m => new NamespaceMetricsReport { Name = Create.RandomName(), CyclicDependencies = Create.Default<string>(m) }, nonics)
                .NamespacesWithCyclicDependencies;
        }
    }
}
