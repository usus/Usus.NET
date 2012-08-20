using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Current
{
    internal static class CurrentMethodInfoCalculator
    {
        public static MethodAndTypeMetrics MethodOfLine(this MetricsReport metrics, LineLocation location)
        {
            if (metrics == null) return null;
            return (metrics.GetMethodOfLine(location)).FirstOrDefault();
        }

        private static IEnumerable<MethodAndTypeMetrics> GetMethodOfLine(this MetricsReport metrics, LineLocation location)
        {
            return from type in metrics.Types
                   from method in metrics.MethodsOfType(type)
                   where IsMethodAtLine(method, location)
                   select new MethodAndTypeMetrics(type, method);
        }

        private static bool IsMethodAtLine(MethodMetricsReport method, LineLocation location)
        {
            return !method.CompilerGenerated
                && method.SourceLocation.IsAvailable
                && string.Compare(method.SourceLocation.Filename, location.File, true) == 0
                && method.SourceLocation.Line >= location.Line;
        }
    }
}
