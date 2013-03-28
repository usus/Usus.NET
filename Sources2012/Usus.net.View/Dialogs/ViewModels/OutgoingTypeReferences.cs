using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
    public class OutgoingTypeReferences
    {
        private readonly TypeMetricsReport source;
        private readonly MetricsReport metrics;

        public OutgoingTypeReferences(MetricsReport metrics, TypeMetricsReport source)
        {
            this.metrics = metrics;
            this.source = source;
        }

        public IEnumerable<OutOfNamespaceReference> Referencing(IEnumerable<NamespaceMetricsReport> namespaces)
        {
            return from type in DependenciesOf(source)
                   where namespaces.Contains(NamespaceOf(type))
                   select new OutOfNamespaceReference(metrics, source, type);
        }

        private IEnumerable<TypeMetricsReport> DependenciesOf(TypeMetricsReport type)
        {
            return from reference in type.InterestingDirectDependencies
                   select metrics.ForType(reference);
        }
  
        private NamespaceMetricsReport NamespaceOf(TypeMetricsReport type)
        {
            return metrics.ForNamespace(type.Namespaces.First());
        }
    }
}