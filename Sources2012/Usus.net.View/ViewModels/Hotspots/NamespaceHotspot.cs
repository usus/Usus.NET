using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.Dialogs;
using andrena.Usus.net.View.Dialogs.ViewModels;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class NamespaceHotspot : Hotspot<NamespaceMetricsReport>
    {
        MetricsReport metrics;

        public NamespaceHotspot(NamespaceMetricsReport namespaceReport, MetricsReport metrics)
            : base(namespaceReport)
        {
            this.metrics = metrics;
        }

        public override void OnDoubleClick(IJumpToSource jumper)
        {
            var cycleDisplay = new NamespaceCycleDisplay();
            cycleDisplay.DataContext = CreateViewModel(jumper);
            cycleDisplay.Show();
        }

        private NamespaceCycleDisplayVM CreateViewModel(IJumpToSource jumper)
        {
            var viewModel = new NamespaceCycleDisplayVM("Namespace cycle");
            viewModel.Display(NamespaceCycle(jumper));
            return viewModel;
        }
  
        private NamespaceCycle NamespaceCycle(IJumpToSource jumper)
        {
            var namespaceCycle = new NamespaceCycle(metrics, NamespacesInCycle());
            namespaceCycle.Jump += type => TypeJump.To(metrics, type, jumper);
            return namespaceCycle;
        }

        private IEnumerable<NamespaceMetricsReport> NamespacesInCycle()
        {
            return from ns in Report.CyclicDependencies
                   select metrics.ForNamespace(ns);
        }
    }
}