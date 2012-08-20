using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.Core.Prepared
{
    public class PreparedMetricsFactory
    {
        MetricsReport _lastMetrics;

        public PreparedMetricsReport Prepare(MetricsReport metrics)
        {
            var preparedMetrics = new PreparedMetricsReport(metrics, _lastMetrics);
            _lastMetrics = metrics;
            return preparedMetrics;
        }
    }
}
