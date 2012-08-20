using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
    public class OutOfNamespaceReference
    {
        private readonly MetricsReport metrics;

        public TypeMetricsReport Source { get; private set; }
        public TypeMetricsReport Target { get; private set; }
        public NamespaceMetricsReport SourceNamespace
        {
            get { return metrics.ForNamespace(Source.Namespaces.First()); }
        }
        public NamespaceMetricsReport TargetNamespace
        {
            get { return metrics.ForNamespace(Target.Namespaces.First()); }
        }

        public OutOfNamespaceReference(MetricsReport metrics, TypeMetricsReport source, TypeMetricsReport target)
        {
            this.metrics = metrics;
            this.Source = source;
            this.Target = target;
        }
    }
}