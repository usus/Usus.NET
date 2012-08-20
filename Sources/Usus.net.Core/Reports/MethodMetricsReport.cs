using System.Collections.Generic;

namespace andrena.Usus.net.Core.Reports
{
    public class MethodMetricsReport
    {
        internal CommonReportKnowledge CommonKnowledge { get; set; }

        public string Name { get; internal set; }
        public string Signature { get; internal set; }
        public bool CompilerGenerated { get; internal set; }
        public bool OnlyDeclaration { get; internal set; }
        public bool DefaultConstructor { get; internal set; }
        public SourceCodeLocation SourceLocation { get; internal set; }

        public int CyclomaticComplexity { get; internal set; }
        public int NumberOfStatements { get; internal set; }
        public int NumberOfRealLines { get; internal set; }
        public int NumberOfLogicalLines { get; internal set; }
        public IEnumerable<string> TypeDependencies { get; internal set; }

        public int MethodLength
        {
            get
            {
                return NumberOfLogicalLines < 1 ? NumberOfStatements : NumberOfLogicalLines;
            }
        }

        internal MethodMetricsReport()
        { }

        public override string ToString()
        {
            return Signature;
        }
    }
}
