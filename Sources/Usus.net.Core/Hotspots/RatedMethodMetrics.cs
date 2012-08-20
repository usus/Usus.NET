using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatedMethodMetrics
    {
        public string Name { get; private set; }
        public string Signature { get; private set; }

        public double CyclomaticComplexity { get; private set; }
        public double RatedCyclomaticComplexity { get; private set; }
        public double MethodLength { get; private set; }
        public double RatedMethodLength { get; private set; }

        internal RatedMethodMetrics(MethodMetricsReport metrics)
        {
            Name = metrics.Name;
            Signature = metrics.Signature;
            CyclomaticComplexity = metrics.CyclomaticComplexity;
            RatedCyclomaticComplexity = metrics.RateCyclomaticComplexity();
            MethodLength = metrics.MethodLength;
            RatedMethodLength = metrics.RateMethodLength();
        }
    }
}
