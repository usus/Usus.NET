using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.View.Dialogs.ViewModels;
using QuickGraph;
using System.Linq;

namespace andrena.Usus.net.View.ViewModels.Graphs
{
	public class Graphs : GraphViewModel
	{
		public IBidirectionalGraph<object, IEdge<object>> NamespacesGraph { get; private set; }
		public IBidirectionalGraph<object, IEdge<object>> TypesGraph { get; private set; }

		public Graphs()
		{
			NamespacesGraph = Graph();
			TypesGraph = Graph();
		}

		private static IBidirectionalGraph<object, IEdge<object>> Graph()
		{
			var graph = new BidirectionalGraph<object, IEdge<object>>(false);
			graph.AddVertexRange(Enumerable.Range(1, 5).Select(i => "Knoten" + i));
			graph.AddEdgeRange(Enumerable.Range(1, 4).Zip(Enumerable.Range(2, 5), (s, t) => new Edge<object>("Knoten" + s, "Knoten" + t)));
			return graph;
		}

		protected override void AnalysisStarted()
		{
		}

		protected override void AnalysisFinished(PreparedMetricsReport metrics)
		{
		}
	}
}
