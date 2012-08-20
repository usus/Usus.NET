using System.Linq;
using Microsoft.Cci;
using andrena.Usus.net.Core.AssemblyNavigation;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class NumberOfFields
    {
        public static int Of(INamedTypeDefinition type)
        {
            return type.Fields.Count(f => !f.IsGeneratedCode());
        }

        public static int NotStaticAndPublic(INamedTypeDefinition type)
        {
            return type.Fields.Count(f 
                => !f.IsStatic 
                && f.Visibility == TypeMemberVisibility.Public
                && !f.IsGeneratedCode());
        }
    }
}
