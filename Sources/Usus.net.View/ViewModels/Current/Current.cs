using System;
using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Current
{
    public class Current : AnalysisAwareViewModel
    {
        PreparedMetricsReport metrics;
        LineLocation lastLocation = new LineLocation();

        public ObservableCollection<CurrentEntry> Entries { get; private set; }

        public Current()
        {
            Entries = new ObservableCollection<CurrentEntry>();
        }

        protected override void AnalysisStarted()
        {
        }

        protected override void AnalysisFinished(PreparedMetricsReport metrics)
        {
            this.metrics = metrics;
        }

        internal Action<LineLocation> RequestLineHandler()
        {
            return line => DisplayMetricsOfMethodAtDefinition(line);
        }

        private void DisplayMetricsOfMethodAtDefinition(LineLocation location)
        {
            if (lastLocation.IsSameAs(location)) return;
            DisplayMetrics(metrics != null ? GetMethodOfDefiniton(location) : null);
        }

        private MethodAndTypeMetrics GetMethodOfDefiniton(LineLocation location)
        {
            lastLocation = location;
            return metrics.Report.MethodOfLine(location);
        }

        private void DisplayMetrics(MethodAndTypeMetrics method)
        {
            Entries.Clear();
            if (method == null)
                DisplayNoMetricsInfo();
            else
                DisplayMetricsInfo(method);
        }

        private void DisplayNoMetricsInfo()
        {
            lastLocation = new LineLocation();
            Entries.Add(new CurrentEntry { Metric = "no metrics yet, consider compiling", Value = "" });
        }

        private void DisplayMetricsInfo(MethodAndTypeMetrics method)
        {
            foreach (var info in method.Info)
                Entries.Add(new CurrentEntry { Metric = info.Item1, Value = info.Item2 });
        }
    }
}
