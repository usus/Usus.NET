using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.View.Hub;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotsCollection : AnalysisAwareViewModel
    {
        public ObservableCollection<HotspotClassSize> ClassSizes { get; private set; }
        public ObservableCollection<HotspotCumulativeComponentDependency> CumulativeComponentDependencies { get; private set; }
        public ObservableCollection<HotspotCyclomaticComplexity> CyclomaticComplexities { get; set; }
        public ObservableCollection<HotspotMethodLength> MethodLengths { get; private set; }
        public ObservableCollection<HotspotNamespaceInCycle> NamespacesInCycle { get; set; }
        public ObservableCollection<HotspotNonStaticPublicFields> NonStaticPublicFields { get; set; }

        public HotspotsCollection()
        {
            ClassSizes = new ObservableCollection<HotspotClassSize>();
            CumulativeComponentDependencies = new ObservableCollection<HotspotCumulativeComponentDependency>();
            CyclomaticComplexities = new ObservableCollection<HotspotCyclomaticComplexity>();
            MethodLengths = new ObservableCollection<HotspotMethodLength>();
            NamespacesInCycle = new ObservableCollection<HotspotNamespaceInCycle>();
            NonStaticPublicFields = new ObservableCollection<HotspotNonStaticPublicFields>();
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
            Dispatch(() => SetClassSizes(metrics.ClassSizeHotspots, metrics.Report));
            Dispatch(() => SetCumulativeComponentDependencies(metrics.CumulativeComponentDependencyHotspots, metrics.Report));
            Dispatch(() => SetCyclomaticComplexities(metrics.CyclomaticComplexityHotspots));
            Dispatch(() => SetMethodLengths(metrics.MethodLengthHotspots));
            Dispatch(() => SetNamespacesInCycle(metrics.NumberOfNamespacesInCycleHotspots, metrics.Report));
            Dispatch(() => SetNonStaticPublicFields(metrics.NumberOfNonStaticPublicFieldsHotspots, metrics.Report));
        }

        private void SetClassSizes(IEnumerable<TypeMetricsReport> classSizes, MetricsReport metrics)
        {
            SetHotspots(ClassSizes, classSizes.OrderByDescending(c => c.ClassSize),
                m => new HotspotClassSize(m, metrics));
        }

        private void SetCumulativeComponentDependencies(IEnumerable<TypeMetricsReport> cumulativeComponentDependencies, MetricsReport metrics)
        {
            SetHotspots(CumulativeComponentDependencies, cumulativeComponentDependencies.OrderByDescending(c => c.CumulativeComponentDependency),
                m => new HotspotCumulativeComponentDependency(m, metrics));
        }

        private void SetCyclomaticComplexities(IEnumerable<MethodMetricsReport> cyclomaticComplexities)
        {
            SetHotspots(CyclomaticComplexities, cyclomaticComplexities.OrderByDescending(m => m.CyclomaticComplexity),
                m => new HotspotCyclomaticComplexity(m));
        }

        private void SetMethodLengths(IEnumerable<MethodMetricsReport> methodLengths)
        {
            SetHotspots(MethodLengths, methodLengths.OrderByDescending(m => m.MethodLength),
                m => new HotspotMethodLength(m));
        }

        private void SetNamespacesInCycle(IEnumerable<NamespaceMetricsReport> namespacesInCycle, MetricsReport metrics)
        {
            SetHotspots(NamespacesInCycle, namespacesInCycle.OrderByDescending(n => n.NumberOfNamespacesInCycle),
                m => new HotspotNamespaceInCycle(m, metrics));
        }

        private void SetNonStaticPublicFields(IEnumerable<TypeMetricsReport> nonStaticPublicFields, MetricsReport metrics)
        {
            SetHotspots(NonStaticPublicFields, nonStaticPublicFields.OrderByDescending(c => c.NumberOfNonStaticPublicFields),
                m => new HotspotNonStaticPublicFields(m, metrics));
        }

        private void SetHotspots<T, S>(ObservableCollection<T> target, IEnumerable<S> source, Func<S, T> constructor)
        {
            foreach (var metrics in source) target.Add(constructor(metrics));
        }
    }
}
