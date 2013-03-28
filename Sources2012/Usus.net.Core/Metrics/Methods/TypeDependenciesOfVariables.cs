using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfVariables
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return from v in method.Body.LocalVariables
                   from t in GetTypesOfVariable(v)
                   select t;
        }

        private static IEnumerable<string> GetTypesOfVariable(ILocalDefinition variable)
        {
            return from t in variable.Type.GetAllRealTypeReferences()
                   select t.ToString();
        }
    }
}
