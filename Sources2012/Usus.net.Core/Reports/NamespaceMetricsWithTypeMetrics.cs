using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
	public class NamespaceMetricsWithTypeMetrics
	{
		public NamespaceMetricsReport Namespace { get; internal set; }
		public string Name { get { return Namespace.Name; } }

		internal bool HasName { get { return !string.IsNullOrEmpty(Namespace.Name); } }

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
