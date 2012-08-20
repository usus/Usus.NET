using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class GeneratedExtensions
    {
        public static bool IsGeneratedCode(this IReference r)
        {
            return r.HasGeneratedCodeAttributes() 
                || r.HasWeirdName();
        }

        private static bool HasWeirdName(this IReference r)
        {
            return r.ToString().Contains("<>");
        }

        private static bool HasGeneratedCodeAttributes(this IReference r)
        {
            return r.Attributes.Any((a => a.IsGeneratedCodeAttribute()));
        }

        private static bool IsGeneratedCodeAttribute(this ICustomAttribute a)
        {
            return a.Type.ToString().Contains("CompilerGeneratedAttribute");
        }
    }
}
