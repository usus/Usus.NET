using System.Collections.Generic;
using andrena.Usus.net.Core.Helper;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class NamespaceExtensions
    {
        public static IEnumerable<string> Namespaces(this INamedTypeDefinition type)
        {
            return AllNamespaces(type).ToList(n => n);
        }

        private static IEnumerable<string> AllNamespaces(this ITypeDefinition type)
        {
            INestedTypeDefinition nestedType = type as INestedTypeDefinition;
            if (nestedType != null)
                return nestedType.AllNamespaces();

            INamespaceTypeReference namespaceType = type as INamespaceTypeReference;
            if (namespaceType != null)
                return namespaceType.AllNamespaces();

            return "".Return();
        }

        private static IEnumerable<string> AllNamespaces(this INestedTypeDefinition nestedType)
        {
            return nestedType.ContainingType.ResolvedType.AllNamespaces();
        }

        private static IEnumerable<string> AllNamespaces(this INamespaceTypeReference namespaceType)
        {
            INestedUnitNamespace nestedNamespace = namespaceType.ContainingUnitNamespace as INestedUnitNamespace;
            return nestedNamespace.AllNamespaces();
        }

        private static IEnumerable<string> AllNamespaces(this INestedUnitNamespace nestedNamespace)
        {
            if (nestedNamespace != null)
            {
                yield return nestedNamespace.ToString();
                foreach (var ns in AllNamespaces(nestedNamespace.ContainingUnitNamespace as INestedUnitNamespace))
                    yield return ns;
            }
        }
    }
}
