using andrena.Usus.net.Core.Prepared;
using QuickGraph;
using System.Linq;

namespace andrena.Usus.net.View.ViewModels.Graphs
{
	public class Graphs : GraphViewModel
	{
		public IBidirectionalGraph<object, IEdge<object>> NamespacesGraph { get; private set; }
		public IBidirectionalGraph<object, IEdge<object>> TypesGraph { get; private set; }

		protected override void AnalysisFinished(PreparedMetricsReport metrics)
		{
			NamespacesGraph = NamespaceGraph(metrics);
			Changed(() => NamespacesGraph);

			TypesGraph = TypeGraph(metrics);
			Changed(() => TypesGraph);
		}

		private static BidirectionalGraph<object, IEdge<object>> NamespaceGraph(PreparedMetricsReport metrics)
		{
			var graph = new BidirectionalGraph<object, IEdge<object>>(false);
			graph.AddVertexRange(metrics.Report.NamespaceGraph.Vertices.Select(v => v.Name));
			graph.AddEdgeRange(metrics.Report.NamespaceGraph.Edges.Select(e => new Edge<object>(e.Item1.Name, e.Item2.Name)));
			return graph;
		}

		private static BidirectionalGraph<object, IEdge<object>> TypeGraph(PreparedMetricsReport metrics)
		{
			var graph = new BidirectionalGraph<object, IEdge<object>>(false);
			graph.AddVertexRange(metrics.Report.TypeGraph.Vertices.Select(v => v.FullName));
			graph.AddEdgeRange(metrics.Report.TypeGraph.Edges.Select(e => new Edge<object>(e.Item1.FullName, e.Item2.FullName)));
			return graph;
		}
	}
}
