using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.View.Dialogs.ViewModels;

namespace andrena.Usus.net.View.ViewModels.TypeCycles
{
	public class TypeCycles : GraphViewModel
	{
		public TypeCycles()
		{

		}

		protected override void AnalysisFinished(PreparedMetricsReport metrics)
		{
			System.Windows.MessageBox.Show(
				string.Format("COMING SOON: cycles of {0} types...", metrics.CommonKnowledge.NumberOfTypes));
		}
	}
}
