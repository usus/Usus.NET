using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfCatches
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return from e in method.Body.OperationExceptionInformation
                   from t in e.ExceptionType.GetAllRealTypeReferences()
                   select t.ToString();
        }
    }
}