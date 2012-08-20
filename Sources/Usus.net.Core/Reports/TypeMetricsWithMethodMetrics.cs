using System.Collections.Generic;

namespace andrena.Usus.net.Core.Reports
{
    internal class TypeMetricsWithMethodMetrics
    {
        public TypeMetricsReport Itself { get; internal set; }
        
        List<MethodMetricsReport> MethodReports;
        public IEnumerable<MethodMetricsReport> Methods
        {
            get { return MethodReports; }
        }

        internal TypeMetricsWithMethodMetrics()
        {
            MethodReports = new List<MethodMetricsReport>();
        }

        internal void AddMethodReports(IEnumerable<MethodMetricsReport> methodMertics)
        {
            MethodReports.AddRange(methodMertics);
        }
    }
}
