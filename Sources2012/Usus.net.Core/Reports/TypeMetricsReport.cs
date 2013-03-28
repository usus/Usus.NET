using System.Collections.Generic;

namespace andrena.Usus.net.Core.Reports
{
    public class TypeMetricsReport
    {
        internal CommonReportKnowledge CommonKnowledge { get; set; }

        public string Name { get; internal set; }
        public string FullName { get; internal set; }
        public SourceCodeLocation SourceLocation { get; internal set; }
        public IEnumerable<string> Namespaces { get; internal set; }
        public bool CompilerGenerated { get; internal set; }
        public int NumberOfFields { get; internal set; }
        public int NumberOfNonStaticPublicFields { get; internal set; }
        public int NumberOfMethods { get; internal set; }
        public IEnumerable<string> DirectDependencies { get; internal set; }
        public IEnumerable<string> InterestingDirectDependencies { get; internal set; }
        public int CumulativeComponentDependency { get; internal set; }

        public int ClassSize { get { return NumberOfMethods; } }

        internal TypeMetricsReport()
        { }

        public override string ToString()
        {
            return FullName;
        }
    }
}
