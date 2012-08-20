using System.Collections.Generic;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfTypeMentions
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return method.TypesOfOperations(
                o => o.IsTypeMentionOperation(),
                o => o.TypeMentionType());
        }

        private static bool IsTypeMentionOperation(this OperationCode o)
        {
            return o == OperationCode.Isinst
                || o == OperationCode.Castclass
                || o == OperationCode.Box
                || o == OperationCode.Ldtoken;
        }

        private static IEnumerable<ITypeReference> TypeMentionType(this IOperation o)
        {
            if (o.Value is ITypeReference)
                yield return o.Value as ITypeReference;
        }
    }
}
