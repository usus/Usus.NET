using andrena.Usus.net.View.ViewModels;
using QuickGraph;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
	public class NamespaceCycleDisplayVM : ViewModel
	{
		public string Header { get; private set; }
		public ObservableCollection<string> MainEntries { get; private set; }
		public ObservableCollection<string> SubEntries { get; private set; }
		public IBidirectionalGraph<object, IEdge<object>> Graph { get; private set; }

		private string layoutAlgorithmType;
		public string LayoutAlgorithmType
		{
			get { return layoutAlgorithmType; }
			set
			{
				layoutAlgorithmType = value;
				Changed(() => LayoutAlgorithmType);
			}
		}
		public IEnumerable<string> LayoutAlgorithmTypes { get; private set; }

		private NamespaceCycle cycle;

		public NamespaceCycleDisplayVM(string header)
		{
			LayoutAlgorithmTypes = new ObservableCollection<string> {
				"BoundedFR", 
				"Circular", 
				"CompoundFDP",
				"EfficientSugiyama", 
				"FR", 
				"ISOM", 
				"KK", 
				"LinLog", 
				"Tree"
			};
			Header = header;
			MainEntries = new ObservableCollection<string>();
			SubEntries = new ObservableCollection<string>();
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
				SubEntries.Add(type.DisplayString());
		}

		public void SelectType(string type)
		{
			cycle.JumpTo(type);
		}
	}
}