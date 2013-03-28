using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;

namespace andrena.Usus.net.Core.Reports
{
    public class Changes
    {
        private readonly MetricsReport _metrics;

        private Changes(MetricsReport metrics)
        {
            _metrics = metrics;
        }

        public static Changes Of(MetricsReport metrics)
        {
            return new Changes(metrics);
        }

        public IEnumerable<MethodMetricsReport> ComparedTo(MetricsReport metrics)
        {
            if (metrics != null)
                return AllChangedMethods(metrics);
            else
                return Enumerable.Empty<MethodMetricsReport>();
        }

        private IEnumerable<MethodMetricsReport> AllChangedMethods(MetricsReport metrics)
        {
            return from m1 in _metrics.Methods
                   join m2 in metrics.Methods
                       on m1.Signature equals m2.Signature
                   where !m1.CompilerGenerated
                   where MethodsDiffer(m1, m2)
                   select m1;
        }

        public bool MethodsDiffer(MethodMetricsReport method1, MethodMetricsReport method2)
        {
            return method1.MethodLength != method2.MethodLength
                   || method1.CyclomaticComplexity != method2.CyclomaticComplexity;
        }
    }
}
