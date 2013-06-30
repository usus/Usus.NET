using andrena.Usus.net.Core.Reports;
using System.Linq;

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

		public string DisplayString()
		{
			return string.Format("{0}\n -> {1} ({2})",
				Source.FullName,
				Target.FullName,
				ReferencingMethods());
		}

		private string ReferencingMethods()
		{
			return string.Join(", ", from method in metrics.MethodsOfType(Source)
									 where method.TypeDependencies.Contains(Target.FullName)
									 select method.Name);
		}
	}
}