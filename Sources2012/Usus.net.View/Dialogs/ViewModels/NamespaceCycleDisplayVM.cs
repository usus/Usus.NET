using QuickGraph;
using System.Collections.ObjectModel;
using System.Linq;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
	public class NamespaceCycleDisplayVM
	{
		public string Header { get; private set; }
		public ObservableCollection<string> MainEntries { get; private set; }
		public ObservableCollection<string> SubEntries { get; private set; }
		public IBidirectionalGraph<object, IEdge<object>> Graph { get; private set; }

		private NamespaceCycle cycle;

		public NamespaceCycleDisplayVM(string header)
		{
			Header = header;
			MainEntries = new ObservableCollection<string>();
			SubEntries = new ObservableCollection<string>();
		}

		public void Display(NamespaceCycle namespaceCycle)
		{
			cycle = namespaceCycle;
			foreach (var namespaceInCycle in cycle.Namespaces) MainEntries.Add(namespaceInCycle);
			
			Graph = CreateExsampleGraph();
		}

		private static IBidirectionalGraph<object, IEdge<object>> CreateExsampleGraph()
		{
			var graph = new BidirectionalGraph<object, IEdge<object>>();
			graph.AddVertexRange(Enumerable.Range(1, 5).Select(i => (object)i));
			graph.AddEdgeRange(Enumerable.Range(1, 4).Zip(Enumerable.Range(2, 5), (s, t) => new Edge<object>(s, t)));
			return graph;
		}

		public void SelectNamespace(string namespaceName)
		{
			SubEntries.Clear();
			foreach (var type in cycle.TypesReferencingOutOf(namespaceName)) SubEntries.Add(type);
		}

		public void SelectType(string type)
		{
			cycle.JumpTo(type);
		}
	}
}