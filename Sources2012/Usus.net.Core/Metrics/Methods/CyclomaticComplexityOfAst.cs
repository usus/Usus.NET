using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class CyclomaticComplexityOfAst
    {
        public static int Of(IMethodDefinition method, PdbReader pdb, IMetadataHost host)
        {
            if (method.HasOperations())
                return method.CalculateCyclomaticComplexity(pdb, host);
            else
                return 0;
        }

        private static int CalculateCyclomaticComplexity(this IMethodDefinition method, PdbReader pdb, IMetadataHost host)
        {
            var methodBody = method.Decompile(pdb, host);
            var cyclomaticComplexityCalculator = new CyclomaticComplexityCalculator();
            cyclomaticComplexityCalculator.Traverse(methodBody.Statements());
            return cyclomaticComplexityCalculator.Result;
        }
    }
}
