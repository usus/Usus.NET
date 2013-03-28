using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    public static class MetricsReportInfoExtensions
    {
        public static DateTime FirstCreated(this IEnumerable<MetricsReport> reports)
        {
            return reports.Min(r => r.Remember.WhenCreated);
        }
    }
}