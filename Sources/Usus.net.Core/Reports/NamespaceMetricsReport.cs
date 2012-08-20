using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    public class NamespaceMetricsReport
    {
        internal CommonReportKnowledge CommonKnowledge { get; set; }

        public string Name { get; internal set; }
        public IEnumerable<string> CyclicDependencies { get; internal set; }
        public int NumberOfNamespacesInCycle { get { return CyclicDependencies.Count(); } }

        internal NamespaceMetricsReport()
        { }
    }
}
