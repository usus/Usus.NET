using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfSignature
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return Enumerable.Empty<string>()
                .Union(method.ReturnTypes())
                .Union(method.ParameterTypes())
                .Union(method.TypesOfGenericsConstraints())
                .ToList();
        }

        private static IEnumerable<string> ReturnTypes(this IMethodDefinition method)
        {
            return from t in method.Type.GetAllRealTypeReferences()
                   select t.ToString();
        }

        private static IEnumerable<string> ParameterTypes(this IMethodDefinition method)
        {
            return from p in method.Parameters
                   from t in p.Type.GetAllRealTypeReferences()
                   where !(t is IGenericMethodParameter)
                   select t.ToString();
        }

        private static IEnumerable<string> TypesOfGenericsConstraints(this IMethodDefinition method)
        {
            return from g in method.GenericParameters
                   from c in g.Constraints
                   from t in c.GetAllRealTypeReferences()
                   select t.ToString();
        }
    }
}
