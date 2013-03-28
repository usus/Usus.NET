using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    internal class NamespaceMetricsWithTypeMetrics
    {
        public NamespaceMetricsReport Itself { get; internal set; }
        public bool HasName { get { return !string.IsNullOrEmpty(Itself.Name); } }

        List<TypeMetricsReport> TypeReports;
        public IEnumerable<TypeMetricsReport> Types
        {
            get { return TypeReports; }
        }

        internal NamespaceMetricsWithTypeMetrics()
        {
            TypeReports = new List<TypeMetricsReport>();
        }

        internal void AddTypeReport(TypeMetricsReport typeReport)
        {
            TypeReports.Add(typeReport);
        }

        internal void AddTypeReports(IEnumerable<NamespaceMetricsWithTypeMetrics> typeReports)
        {
            TypeReports.AddRange(typeReports.SelectMany(n => n.TypeReports));
        }
    }
}
