using QuickGraph;
using System.Collections.ObjectModel;
using System.Linq;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
	public class NamespaceCycleDisplayVM : GraphViewModel
	{
		public string Header { get; private set; }
		public ObservableCollection<string> MainEntries { get; private set; }
		public ObservableCollection<OutOfNamespaceReferenceVM> SubEntries { get; private set; }
		public IBidirectionalGraph<object, IEdge<object>> Graph { get; private set; }

		private NamespaceCycle cycle;

		public NamespaceCycleDisplayVM(string header)
		{
			Header = header;
			MainEntries = new ObservableCollection<string>();
			SubEntries = new ObservableCollection<OutOfNamespaceReferenceVM>();
		}

		public void Display(NamespaceCycle namespaceCycle)
		{
			cycle = namespaceCycle;

			FillMainEntries();
			FillGraph();
		}

		private void FillMainEntries()
		{
			foreach (var namespaceInCycle in cycle.Namespaces)
				MainEntries.Add(namespaceInCycle);
		}

		private void FillGraph()
		{
			var graph = new BidirectionalGraph<object, IEdge<object>>(false);
			graph.AddVertexRange(cycle.Namespaces);
			graph.AddEdgeRange(
				from namespaceInCycle in cycle.Namespaces
				from outOfNamespaceReference in cycle.TypesReferencingOutOf(namespaceInCycle)
				select new Edge<object>(namespaceInCycle, outOfNamespaceReference.TargetNamespace.Name));
			Graph = graph;
		}

		public void SelectNamespace(string namespaceName)
		{
			SubEntries.Clear();
			foreach (var type in cycle.TypesReferencingOutOf(namespaceName))
				SubEntries.Add(new OutOfNamespaceReferenceVM(type));
		}

		public void SelectType(string type)
		{
			cycle.JumpTo(type);
		}
	}
}