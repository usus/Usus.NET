using System;
using System.Linq;
using andrena.Usus.net.Core.Helper.Reflection;

namespace andrena.Usus.net.Core.Reports
{
    public static class TypeMetricsReportSearch
    {
        public static TypeMetricsReport ForType<T>(this MetricsReport metrics)
        {
            return metrics.ForType(typeof(T));
        }
     
        public static TypeMetricsReport ForType(this MetricsReport metrics, Type type)
        {
            return metrics.ForType(type.GetFullName());
        }

        public static TypeMetricsReport ForType(this MetricsReport metrics, string typeName)
        {
            return metrics.TypeForName(typeName);
        }
    }
}
