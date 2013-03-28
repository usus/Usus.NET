
namespace andrena.Usus.net.Core.Reports
{
    public class CommonReportKnowledge
    {
        public int NumberOfMethods { get; private set; }
        public int NumberOfTypes { get; private set; }
        public int NumberOfNamespaces { get; private set; }
        public int RelevantLinesOfCode { get; private set; }
        public int NumberOfAssemblies { get; private set; }

        internal CommonReportKnowledge()
        {
            NumberOfAssemblies = 1;
        }

        internal CommonReportKnowledge(int methods, int classes, int namespaces, int rlocs)
        {
            NumberOfMethods = methods;
            NumberOfTypes = classes;
            NumberOfNamespaces = namespaces;
            RelevantLinesOfCode = rlocs;
            NumberOfAssemblies = 1;
        }

        internal void UpdateFor(MethodMetricsReport method)
        {
            if (!method.CompilerGenerated)
            {
                NumberOfMethods++;
                RelevantLinesOfCode += LinesOfMethodDefintion(method);
            }
        }

        private static int LinesOfMethodDefintion(MethodMetricsReport method)
        {
            return 1 + method.MethodLength;
        }

        internal void UpdateFor(TypeMetricsReport type)
        {
            if (!type.CompilerGenerated)
            {
                NumberOfTypes++;
                RelevantLinesOfCode += 2 + type.NumberOfFields;
            }
        }

        internal void UpdateFor(NamespaceMetricsWithTypeMetrics namespaceMertics)
        {
            NumberOfNamespaces++;
        }

        internal void SetAssemblies(int count)
        {
            NumberOfAssemblies = count;
        }
    }
}
