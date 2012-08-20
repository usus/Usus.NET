using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class NumberOfMethods
    {
        public static int Of(INamedTypeDefinition type)
        {
            return type.Methods.Count(m => !m.IsDefaultCtor());
        }
    }
}
