using System.Diagnostics;
using System.Linq;
using System.Reflection;
using andrena.Usus.net.Core.Helper.Reflection;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    internal static class VerifyMethods
    {
        internal static bool VerifyMethodMetrics<T>(this MethodWithAttributes<T> method, MetricsReport metrics) where T : MethodExpectation
        {
            return method.Attributes.All(a => a.VerifyMethod<T>(method.Method, metrics));
        }

        private static bool VerifyMethod<T>(this T expectation, MethodInfo method, MetricsReport metrics) where T : MethodExpectation
        {
            Debug.WriteLine("verify " + method.Name);
            var methodMetrics = metrics.GetMethodMetrics(method);
            if (expectation.Verify(methodMetrics)) return true;
            throw new VerificationException(method, expectation);
        }

        private static MethodMetricsReport GetMethodMetrics(this MetricsReport metrics, MethodInfo method)
        {
            var methodMetrics = metrics.ForMethod(method);
            if (methodMetrics != null) return methodMetrics;
            throw new MetricsNotFoundException(method);
        }
    }
}
