using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace andrena.Usus.net.View.ViewModels
{
	public abstract class GraphViewModel : AnalysisAwareViewModel
	{
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

		public GraphViewModel()
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
		}

		protected override void AnalysisStarted()
		{
		}

		protected override void AnalysisFinished(Core.Prepared.PreparedMetricsReport metrics)
		{
		}
	}
}
