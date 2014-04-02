using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.View.Dialogs.NamespaceCycles
{
	public class NamespaceCycle
	{
		private readonly IEnumerable<NamespaceMetricsReport> namespaces;
		private readonly MetricsReport metrics;

		public NamespaceCycle(MetricsReport metrics, IEnumerable<NamespaceMetricsReport> namespaces)
		{
			this.metrics = metrics;
			this.namespaces = namespaces;
			Jump += type => { };
		}

		public event Action<TypeMetricsReport> Jump;

		public IEnumerable<string> Namespaces
		{
			get { return namespaces.Select(n => n.Name); }
		}

		public IEnumerable<TypeReference> TypesReferencingOutOf(string namespaceName)
		{
			var currentNamespace = metrics.ForNamespace(namespaceName);
			var otherNamespaceInCycle = namespaces.ExceptThis(currentNamespace).ToList();
			return from reference in ReferencesOutOf(currentNamespace, to: otherNamespaceInCycle)
				   select reference;
		}

		private IEnumerable<TypeReference> ReferencesOutOf(NamespaceMetricsReport currentNamespace, IEnumerable<NamespaceMetricsReport> to)
		{
			return from typeReferences in AllTypesWithReferencesIn(currentNamespace)
				   from crossReference in typeReferences.Referencing(to)
				   select crossReference;
		}

		private IEnumerable<OutgoingTypeReferences> AllTypesWithReferencesIn(NamespaceMetricsReport currentNamespace)
		{
			return from type in metrics.TypesOfNamespace(currentNamespace)
				   select new OutgoingTypeReferences(metrics, type);
		}

		public void JumpTo(string type)
		{
			Jump(metrics.ForType(type.Substring(0, type.IndexOf("\n"))));
		}
	}
}
