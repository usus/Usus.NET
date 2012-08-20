using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class Hotspots : HotspotsCollection
    {
        public IJumpToSource SourceLocating { private get; set; }

        public string CumulativeComponentDependenciesText { get; private set; }
        
        protected override void AnalysisFinished(PreparedMetricsReport metrics)
        {
            base.AnalysisFinished(metrics);
            Dispatch(() => SetCumulativeComponentDependenciesText(metrics.CommonKnowledge));
        }

        private void SetCumulativeComponentDependenciesText(CommonReportKnowledge reportKnowledge)
        {
            CumulativeComponentDependenciesText = string.Format("Classes with more than {0} cumulated dependencies.", RatingFunctions.Limits.CumulativeComponentDependency(reportKnowledge));
            Changed(() => CumulativeComponentDependenciesText);
        }

        public void DoubleClick(object clickedOn)
        {
            var clickable = clickedOn as IDoubleClickable<IJumpToSource>;
            if (clickable != null && SourceLocating != null) 
                clickable.OnDoubleClick(SourceLocating);
        }
    }
}
