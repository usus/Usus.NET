using System.Collections.Generic;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedMetrics
    {
        public MetricsReport Metrics { get; private set; }

        public IEnumerable<RatedMethodMetrics> RatedMethods { get; private set; }
        public IEnumerable<RatedTypeMetrics> RatedTypes { get; private set; }
        public IEnumerable<RatedNamespaceMetrics> RatedNamespaces { get; private set; }

        public double AverageRatedCyclomaticComplexity { get; private set; }
        public double AverageRatedMethodLength { get; private set; }
        public double AverageRatedClassSize { get; private set; }
        public double AverageRatedNumberOfNonStaticPublicFields { get; private set; }
        public double AverageComponentDependency { get; private set; }
        public double NamespacesWithCyclicDependencies { get; private set; }

        internal RatedMetrics(MetricsReport metrics)
        {
            Metrics = metrics;
            InitializeRatedLists(metrics);
            InitializeStatistics(metrics);
        }

        private void InitializeRatedLists(MetricsReport metrics)
        {
            RatedMethods = metrics.Methods.ToList(m => m.Rate(), m => !m.CompilerGenerated && !m.OnlyDeclaration);
            RatedTypes = metrics.Types.ToList(m => m.Rate(), m => !m.CompilerGenerated);
            RatedNamespaces = metrics.Namespaces.ToList(m => m.Rate());
        }

        private void InitializeStatistics(MetricsReport metrics)
        {
            AverageRatedCyclomaticComplexity = RatedMethods.AverageAny(m => m.RatedCyclomaticComplexity, m => m.CyclomaticComplexity > 0);
            AverageRatedMethodLength = RatedMethods.AverageAny(m => m.RatedMethodLength, m => m.MethodLength > 0);
            AverageRatedClassSize = RatedTypes.AverageAny(m => m.RatedClassSize);
            AverageRatedNumberOfNonStaticPublicFields = RatedTypes.AverageAny(m => m.RatedNumberOfNonStaticPublicFields);
            AverageComponentDependency = RatedTypes.AverageAny(m => m.CumulativeComponentDependency) / metrics.CommonKnowledge.NumberOfTypes;
            NamespacesWithCyclicDependencies = (double)RatedNamespaces.CountAny(m => m.IsInCycle) / metrics.CommonKnowledge.NumberOfNamespaces;
        }
    }
}
