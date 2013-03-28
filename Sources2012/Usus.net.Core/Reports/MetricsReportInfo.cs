using System;

namespace andrena.Usus.net.Core.Reports
{
    public class MetricsReportInfo
    {
        public DateTime WhenCreated { get; internal set; }
        public DateTime WhenAssemblyAnalysisDone { get; internal set; }
        public DateTime WhenPostProcessingDone { get; internal set; }

        public MetricsReportInfo()
        {
            WhenCreated = DateTime.Now;
        }

        public void AssemblyAnalysisDone()
        {
            WhenAssemblyAnalysisDone = DateTime.Now;
        }

        public void PostProcessingDone()
        {
            WhenPostProcessingDone = DateTime.Now;
        }
    }
}