using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public static class RatingFunctions
    {
        public static RatingFunctionLimits Limits { get; set; }

        static RatingFunctions()
        {
            Limits = new RatingFunctionLimits();
        }

        internal static double RateCyclomaticComplexity(this MethodMetricsReport metrics)
        {
            if (metrics.CyclomaticComplexity > Limits.CyclomaticComplexity(metrics.CommonKnowledge))
                return ((1.0 / Limits.CyclomaticComplexity(metrics.CommonKnowledge)) * metrics.CyclomaticComplexity) - 1;
            else
                return 0.0;
        }

        internal static double RateMethodLength(this MethodMetricsReport metrics)
        {
            if (metrics.MethodLength > Limits.MethodLength(metrics.CommonKnowledge))
                return ((1.0 / Limits.MethodLength(metrics.CommonKnowledge)) * metrics.MethodLength) - 1;
            else
                return 0.0;
        }

        internal static double RateClassSize(this TypeMetricsReport metrics)
        {
            if (metrics.ClassSize > Limits.ClassSize(metrics.CommonKnowledge))
                return ((1.0 / Limits.ClassSize(metrics.CommonKnowledge)) * metrics.ClassSize) - 1;
            else
                return 0.0;
        }

        internal static double RateNumberOfNonStaticPublicFields(this TypeMetricsReport metrics)
        {
            if (metrics.NumberOfNonStaticPublicFields > Limits.NumberOfNonStaticPublicFields(metrics.CommonKnowledge))
                return 1.0;
            else
                return 0.0;
        }

        internal static bool RateNumberOfNamespacesInCycle(this NamespaceMetricsReport metrics)
        {
            if (metrics.NumberOfNamespacesInCycle > Limits.NumberOfNamespacesInCycle(metrics.CommonKnowledge))
                return true;
            else
                return false;
        }
    }
}
