using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using andrena.Usus.net.Core.Prepared;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.ViewModels.Hotspots;

namespace andrena.Usus.net.View.ViewModels.Cockpit
{
    public class Cockpit : AnalysisAwareViewModel
    {
        CockpitEntry _AverageComponentDependency;
        CockpitEntry _ClassSize;
        CockpitEntry _CyclomaticComplexity;
        CockpitEntry _MethodLength;
        CockpitEntry _NonStaticPublicFields;
        CockpitEntry _NamespacesWithCycles;

        public ObservableCollection<CockpitEntry> Entries { get; private set; }
        public IEnumerable<MethodMetricsReport> ChangedMethods { get; private set; }
        public string Rloc { get; private set; }
        public string LastMetricsTime { get; private set; }

        public IJumpToSource SourceLocating { private get; set; }

        public Cockpit()
        {
            Entries = new ObservableCollection<CockpitEntry>();
            Entries.Add(_AverageComponentDependency = new CockpitEntry("Average Component Dependency", n => n + " types"));
            Entries.Add(_ClassSize = new CockpitEntry("Class Size", n => n + " types"));
            Entries.Add(_CyclomaticComplexity = new CockpitEntry("Cyclomatic Complexity", n => n + " methods"));
            Entries.Add(_MethodLength = new CockpitEntry("Method Length", n => n + " methods"));
            Entries.Add(_NonStaticPublicFields = new CockpitEntry("Non-Static Public Fields", n => n + " types"));
            Entries.Add(_NamespacesWithCycles = new CockpitEntry("Namespaces with Cycles", n => n + " namespaces"));
        }

        protected override void AnalysisStarted()
        { }

        protected override void AnalysisFinished(PreparedMetricsReport metrics)
        {
            ChangedMethods = metrics.ChangedMethods;
            Dispatch(() =>
            {
                SetACD(metrics);
                SetClassSize(metrics);
                SetCyclomaticComplexity(metrics);
                SetMethodLength(metrics);
                SetNumberOfNonStaticPublicFields(metrics);
                SetNamespacesWithCycles(metrics);
                SetFooter(metrics);
            });
        }

        private void SetFooter(PreparedMetricsReport metrics)
        {
            Rloc = string.Format("{0} Relevant Lines Of Code", metrics.CommonKnowledge.RelevantLinesOfCode);
            Changed(() => Rloc);
            LastMetricsTime = string.Format("  ({0})", DateTime.Now.ToShortTimeString());
            Changed(() => LastMetricsTime);
        }

        private void SetACD(PreparedMetricsReport metrics)
        {
            _AverageComponentDependency.Update(
                metrics.Rated.AverageComponentDependency,
                metrics.CommonKnowledge.NumberOfTypes,
                metrics.CumulativeComponentDependencyHotspots.Count(),
                metrics.CumulativeComponentDependencyHistogram.GeometricalFit.Parameter);
        }

        private void SetClassSize(PreparedMetricsReport metrics)
        {
            _ClassSize.Update(
                metrics.Rated.AverageRatedClassSize,
                metrics.CommonKnowledge.NumberOfTypes,
                metrics.ClassSizeHotspots.Count(),
                metrics.ClassSizeHistogram.GeometricalFit.Parameter);
        }

        private void SetCyclomaticComplexity(PreparedMetricsReport metrics)
        {
            _CyclomaticComplexity.Update(
                metrics.Rated.AverageRatedCyclomaticComplexity,
                metrics.CommonKnowledge.NumberOfMethods,
                metrics.CyclomaticComplexityHotspots.Count(),
                metrics.CyclomaticComplexityHistogram.GeometricalFit.Parameter);
        }

        private void SetMethodLength(PreparedMetricsReport metrics)
        {
            _MethodLength.Update(
                metrics.Rated.AverageRatedMethodLength,
                metrics.CommonKnowledge.NumberOfMethods,
                metrics.MethodLengthHotspots.Count(),
                metrics.MethodLengthHistogram.GeometricalFit.Parameter);
        }

        private void SetNumberOfNonStaticPublicFields(PreparedMetricsReport metrics)
        {
            _NonStaticPublicFields.Update(
                metrics.Rated.AverageRatedNumberOfNonStaticPublicFields,
                metrics.CommonKnowledge.NumberOfTypes,
                metrics.NumberOfNonStaticPublicFieldsHotspots.Count(),
                metrics.NumberOfNonStaticPublicFieldsHistogram.GeometricalFit.Parameter);
        }

        private void SetNamespacesWithCycles(PreparedMetricsReport metrics)
        {
            _NamespacesWithCycles.Update(
                metrics.Rated.NamespacesWithCyclicDependencies,
                metrics.CommonKnowledge.NumberOfNamespaces,
                metrics.NumberOfNamespacesInCycleHotspots.Count(),
                metrics.NumberOfNamespacesInCycleHistogram.GeometricalFit.Parameter);
        }

        public void JumpToMethod(MethodMetricsReport method)
        {
            if (SourceLocating != null)
                new MethodHotspot(method).OnDoubleClick(SourceLocating);
        }
    }
}
