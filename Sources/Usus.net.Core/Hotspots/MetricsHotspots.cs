using System.Collections.Generic;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class MetricsHotspots
    {
        public MetricsReport Metrics { get; private set; }
        
        internal MetricsHotspots(MetricsReport metrics)
        {
            Metrics = metrics;
        }

        public IEnumerable<MethodMetricsReport> OfCyclomaticComplexity()
        {
            return Metrics.MethodsOverLimit(m => m.CyclomaticComplexity, l => l.CyclomaticComplexity, m => !m.CompilerGenerated);
        }

        public IEnumerable<MethodMetricsReport> OfCyclomaticComplexityOver(int limit)
        {
            return Metrics.MethodsOverLimit(m => m.CyclomaticComplexity, l => _ => limit, m => !m.CompilerGenerated);
        }

        public IEnumerable<MethodMetricsReport> OfMethodLength()
        {
            return Metrics.MethodsOverLimit(m => m.MethodLength, l => l.MethodLength, m => !m.CompilerGenerated);
        }

        public IEnumerable<MethodMetricsReport> OfMethodLengthOver(int limit)
        {
            return Metrics.MethodsOverLimit(m => m.MethodLength, l => _ => limit, m => !m.CompilerGenerated);
        }

        public IEnumerable<TypeMetricsReport> OfClassSize()
        {
            return Metrics.TypesOverLimit(m => m.ClassSize, l => l.ClassSize, t => !t.CompilerGenerated);
        }

        public IEnumerable<TypeMetricsReport> OfClassSizeOver(int limit)
        {
            return Metrics.TypesOverLimit(m => m.ClassSize, l => _ => limit, t => !t.CompilerGenerated);
        }

        public IEnumerable<TypeMetricsReport> OfNumberOfNonStaticPublicFields()
        {
            return Metrics.TypesOverLimit(m => m.NumberOfNonStaticPublicFields, l => l.NumberOfNonStaticPublicFields, t => !t.CompilerGenerated);
        }

        public IEnumerable<TypeMetricsReport> OfCumulativeComponentDependency()
        {
            return Metrics.TypesOverLimit(m => m.CumulativeComponentDependency, l => l.CumulativeComponentDependency, t => !t.CompilerGenerated);
        }

        public IEnumerable<NamespaceMetricsReport> OfNamespacesInCycle()
        {
            return Metrics.NamespacesOverLimit(m => m.NumberOfNamespacesInCycle, l => l.NumberOfNamespacesInCycle);
        }
    }
}
