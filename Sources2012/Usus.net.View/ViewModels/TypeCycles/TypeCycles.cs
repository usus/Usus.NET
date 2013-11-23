using andrena.Usus.net.Core.Graphs;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.Core.Reports;
using QuickGraph;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace andrena.Usus.net.View.ViewModels.TypeCycles
{
	public class TypeCycles : GraphViewModel
	{
		public TypeCycles()
		{
			AllCycles = new ObservableCollection<TypeCycle>();
		}

		public IBidirectionalGraph<object, IEdge<object>> Graph { get; private set; }

		public ObservableCollection<TypeCycle> AllCycles { get; private set; }

		private TypeCycle _SelectedCycle;
		public TypeCycle SelectedCycle
		{
			get
			{
				return _SelectedCycle;
			}
			set
			{
				if (_SelectedCycle != value)
				{
					_SelectedCycle = value;
					Changed(() => SelectedCycle);

					if (_SelectedCycle != null)
						UpdateGraph(_SelectedCycle);
				}
			}
		}

		private Type _SelectedType;
		public Type SelectedType
		{
			get
			{
				return _SelectedType;
			}
			set
			{
				if (_SelectedType != value)
				{
					_SelectedType = value;
					Changed(() => SelectedType);
				}
			}
		}

		protected override void AnalysisFinished(PreparedMetricsReport metrics)
		{
			var graph = GetTypeGraph(metrics);
			var cycles = graph.Cycles();
			var cycleVMs = GetViewModels(metrics, cycles);
			Display(cycleVMs);
		}

		private static IGraph<TypeMetricsReport> GetTypeGraph(PreparedMetricsReport metrics)
		{
			var graph = metrics.Report.TypeGraph.Clone();
			var typesToIgnore = graph.Vertices.Where(t => t.CompilerGenerated).ToList();
			foreach (var type in typesToIgnore)
			{
				graph.Ignore(type);
			}
			return graph;
		}

		private static IEnumerable<TypeCycle> GetViewModels(PreparedMetricsReport metrics, StronglyConntectedComponents<TypeMetricsReport> cycles)
		{
			return from cycle in cycles.All
				   where cycle.VertexCount > 1
				   orderby cycle.VertexCount descending
				   select new TypeCycle
				   {
					   DisplayName = string.Format("{0} classes", cycle.VertexCount),
					   TypesInCycle = from type in cycle.Vertices
									  select new Type
									  {
										  DisplayName = type.FullName,
										  ReferencedTypes = from referencedType in type.InterestingDirectDependencies.Intersect(cycles.OfVertex(type).Vertices.Select(t => t.FullName))
															where type.FullName != referencedType
															select new TypeReferenceVM(metrics, type, referencedType)
									  }
				   };
		}

		private void Display(IEnumerable<TypeCycle> cycleVMs)
		{
			Dispatch(() =>
						{
							AllCycles.Clear();
							foreach (var cycleVM in cycleVMs)
							{
								AllCycles.Add(cycleVM);
							}
						});
		}

		private void UpdateGraph(TypeCycle cycle)
		{
			var graph = new BidirectionalGraph<object, IEdge<object>>(false);
			graph.AddVertexRange(cycle.TypesInCycle.Select(t => t.DisplayName));
			graph.AddEdgeRange(
				from type in cycle.TypesInCycle
				from referencedType in type.ReferencedTypes
				select new Edge<object>(referencedType.Source, referencedType.Target));
			Graph = graph;
			Changed(() => Graph);
		}

		public void Jump()
		{
			MessageBox.Show("coming soon");
		}
	}
}