using System.Collections.Generic;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;
using Microsoft.Cci.Immutable;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfCallOperations
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return method.TypesOfOperations(
                o => o.IsCallOperation(), 
                o => o.CalleeTypes());
        }

        private static bool IsCallOperation(this OperationCode o)
        {
            return o == OperationCode.Call
                || o == OperationCode.Calli
                || o == OperationCode.Callvirt;
        }

        private static IEnumerable<ITypeReference> CalleeTypes(this IOperation o)
        {
            yield return (o.Value as ITypeMemberReference).ContainingType;
            if (o.Value is GenericMethodInstanceReference)
                foreach (var genericArgument in GetGenericArguments(o))
                    yield return genericArgument;
        }
  
        private static IEnumerable<ITypeReference> GetGenericArguments(IOperation o)
        {
            return (o.Value as GenericMethodInstanceReference).GenericArguments;
        }
    }
}
