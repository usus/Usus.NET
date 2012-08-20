using System;

namespace andrena.Usus.net.Core.Reports
{
    public class PropertyMetricsReport
    {
        public MethodMetricsReport Getter { get; internal set; }
        public MethodMetricsReport Setter { get; internal set; }

        internal PropertyMetricsReport()
        {
        }
    }
}