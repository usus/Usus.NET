using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class TypeExtensions
    {
        public static string FullName(this ITypeDefinition type)
        {
            string typeName = type.IsGeneric ? type.InstanceType.ToString() : type.ToString();
            return typeName.Replace(", ", ",");
        }

        public static string Name(this INamedTypeDefinition type)
        {
            return type.Name.ToString();
        }
    }
}
