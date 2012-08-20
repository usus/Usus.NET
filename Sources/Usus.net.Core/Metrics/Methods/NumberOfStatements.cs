using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfStatements
    {
        public static int Of(IMethodDefinition method, PdbReader pdb, IMetadataHost host)
        {
            if (method.HasOperations())
                return method.CalculateStatements(pdb, host);
            else
                return 0;
        }

        private static int CalculateStatements(this IMethodDefinition method, PdbReader pdb, IMetadataHost host)
        {
            var methodBody = method.Decompile(pdb, host);
            var statementCollector = new StatementCollector(pdb);
            statementCollector.Traverse(methodBody.Statements());
            return statementCollector.ResultCount;
        }
    }
}
