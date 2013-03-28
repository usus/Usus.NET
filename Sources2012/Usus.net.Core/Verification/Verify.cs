using System.Linq;
using System.Reflection;
using andrena.Usus.net.Core.Helper.Reflection;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    public static class Verify
    {
        public static bool MethodsWith<T>(MetricsReport metrics) where T : MethodExpectation
        {
            var methods = Assembly.GetCallingAssembly().GetMethodsWithAssigned<T>();
            return methods.All(m => m.VerifyMethodMetrics<T>(metrics));
        }
     
        public static bool TypesWith<T>(MetricsReport metrics) where T : TypeExpectation
        {
            var types = Assembly.GetCallingAssembly().GetTypesWithAssigned<T>();
            return types.All(t => t.VerifyTypeMetrics<T>(metrics));
        }
    }
}
