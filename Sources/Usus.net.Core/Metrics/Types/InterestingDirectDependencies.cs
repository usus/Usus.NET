using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class InterestingDirectDependencies
    {
        public static IEnumerable<string> Of(TypeMetricsReport type, IEnumerable<TypeMetricsReport> otherTypes)
        {
            return type.DirectDependencies
                .Intersect(otherTypes.Select(t => t.FullName))
                .ToList();
        }
    }
}
