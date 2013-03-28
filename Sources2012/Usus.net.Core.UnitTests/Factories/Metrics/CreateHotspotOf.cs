using System.Collections.Generic;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace Usus.net.Core.UnitTests.Factories.Metrics
{
    public static class CreateHotspotOf
    {
        public static IEnumerable<MethodMetricsReport> CyclomaticComplexity(params int[] ccs)
        {
            return CreateMany.Metrics(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .Hotspots().OfCyclomaticComplexity();
        }

        public static IEnumerable<MethodMetricsReport> CyclomaticComplexityUnderLimit(int limit, params int[] ccs)
        {
            return CreateMany.Metrics(m => new MethodMetricsReport { CyclomaticComplexity = m }, ccs)
                .Hotspots().OfCyclomaticComplexityOver(limit);
        }

        public static IEnumerable<MethodMetricsReport> MethodLength(params int[] mls)
        {
            return CreateMany.Metrics(m => new MethodMetricsReport { NumberOfLogicalLines = m }, mls)
                .Hotspots().OfMethodLength();
        }

        public static IEnumerable<TypeMetricsReport> ClassSize(params int[] css)
        {
            return CreateMany.Metrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfMethods = m }, css)
                .Hotspots().OfClassSize();
        }

        public static IEnumerable<TypeMetricsReport> NumberOfNonStaticPublicFields(params int[] nspfs)
        {
            return CreateMany.Metrics(m => new TypeMetricsReport { FullName = Create.RandomName(), NumberOfNonStaticPublicFields = m }, nspfs)
                .Hotspots().OfNumberOfNonStaticPublicFields();
        }

        public static IEnumerable<TypeMetricsReport> CumulativeComponentDependency(params int[] ccds)
        {
            return CreateMany.Metrics(m => new TypeMetricsReport { FullName = Create.RandomName(), CumulativeComponentDependency = m }, ccds)
                .Hotspots().OfCumulativeComponentDependency();
        }

        public static IEnumerable<NamespaceMetricsReport> NumberOfNamespacesInCycle(params int[] cds)
        {
            return CreateMany.Metrics(m => new NamespaceMetricsReport { Name = Create.RandomName(), CyclicDependencies = Create.Default<string>(m) }, cds)
                .Hotspots().OfNamespacesInCycle();
        }
    }
}
