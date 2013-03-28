using System;
using System.Diagnostics;
using System.Linq;
using andrena.Usus.net.Core.Helper.Reflection;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Verification
{
    internal static class VerifyTypes
    {
        internal static bool VerifyTypeMetrics<T>(this TypeWithAttributes<T> type, MetricsReport metrics) where T : TypeExpectation
        {
            return type.Attributes.All(a => a.VerifyType<T>(type.Type, metrics));
        }

        private static bool VerifyType<T>(this T expectation, Type type, MetricsReport metrics) where T : TypeExpectation
        {
            Debug.WriteLine("verify " + type.Name);
            var typeMetrics = metrics.GetTypeMetrics(type);
            if (expectation.Verify(typeMetrics)) return true;
            throw new VerificationException(type, expectation);
        }

        private static TypeMetricsReport GetTypeMetrics(this MetricsReport metrics, Type type)
        {
            var typeMetrics = metrics.ForType(type);
            if (typeMetrics != null) return typeMetrics;
            throw new MetricsNotFoundException(type);
        }
    }
}