using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Math;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels.Distributions
{
    public class Distributions : AnalysisAwareViewModel
    {
        public ObservableCollection<KeyValuePair<double, double>> ClassSizes { get; private set; }
        public ObservableCollection<KeyValuePair<double, double>> CumulativeComponentDependencies { get; private set; }
        public ObservableCollection<KeyValuePair<double, double>> CyclomaticComplexities { get; set; }
        public ObservableCollection<KeyValuePair<double, double>> MethodLengths { get; private set; }
        public ObservableCollection<KeyValuePair<double, double>> NamespacesInCycle { get; set; }
        public ObservableCollection<KeyValuePair<double, double>> NonStaticPublicFields { get; set; }

        public string ClassSizesText { get; private set; }
        public string CumulativeComponentDependenciesText { get; private set; }
        public string CyclomaticComplexitiesText { get; set; }
        public string MethodLengthsText { get; private set; }
        public string NamespacesInCycleText { get; set; }
        public string NonStaticPublicFieldsText { get; set; }

        public Distributions()
        {
            ClassSizes = new ObservableCollection<KeyValuePair<double, double>>();
            CumulativeComponentDependencies = new ObservableCollection<KeyValuePair<double, double>>();
            CyclomaticComplexities = new ObservableCollection<KeyValuePair<double, double>>();
            MethodLengths = new ObservableCollection<KeyValuePair<double, double>>();
            NamespacesInCycle = new ObservableCollection<KeyValuePair<double, double>>();
            NonStaticPublicFields = new ObservableCollection<KeyValuePair<double, double>>();
        }

        protected override void AnalysisStarted()
        {
        }

        private void ClearLists()
        {
            ClassSizes.Clear();
            CumulativeComponentDependencies.Clear();
            CyclomaticComplexities.Clear();
            MethodLengths.Clear();
            NamespacesInCycle.Clear();
            NonStaticPublicFields.Clear();
        }

        protected override void AnalysisFinished(PreparedMetricsReport metrics)
        {
            Dispatch(ClearLists);
            ClassSizesText = Fit(HistogramOf(ClassSizes, metrics.ClassSizeHistogram));
            CumulativeComponentDependenciesText = Fit(HistogramOf(CumulativeComponentDependencies, metrics.CumulativeComponentDependencyHistogram));
            CyclomaticComplexitiesText = Fit(HistogramOf(CyclomaticComplexities, metrics.CyclomaticComplexityHistogram));
            MethodLengthsText = Fit(HistogramOf(MethodLengths, metrics.MethodLengthHistogram));
            NamespacesInCycleText = Fit(HistogramOf(NamespacesInCycle, metrics.NumberOfNamespacesInCycleHistogram));
            NonStaticPublicFieldsText = Fit(HistogramOf(NonStaticPublicFields, metrics.NumberOfNonStaticPublicFieldsHistogram));
            ChangeAllTexts();
        }

        private void ChangeAllTexts()
        {
            Changed(() => ClassSizesText);
            Changed(() => CumulativeComponentDependenciesText);
            Changed(() => CyclomaticComplexitiesText);
            Changed(() => MethodLengthsText);
            Changed(() => NamespacesInCycleText);
            Changed(() => NonStaticPublicFieldsText);
        }

        private string Fit(Distribution distribution)
        {
            return "Geometric Distribution (\u03BB(1 - \u03BB)^(x-1)): \u03BB = " + distribution.GeometricalFit.Parameter.Value();
        }

        private Distribution HistogramOf(ObservableCollection<KeyValuePair<double, double>> target, Distribution distribution)
        {
            Dispatch(() =>
            {
                for (int i = 0; i < Math.Min(50, distribution.Histogram.BinCount); i++)
                    target.Add(new KeyValuePair<double, double>(i, distribution.Histogram.ElementsInBin(i)));
            });
            return distribution;
        }
    }
}
