using System.Linq;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotCyclomaticComplexity : MethodHotspot
    {
    	private readonly MetricsReport mMetrics;

    	public int Complexity { get { return Report.CyclomaticComplexity; } }
        public string Method { get { return Report.Name; } }
        public string Signature { get { return Report.Signature; } }
		public string Type { get { return mMetrics.ForTypeOf(Report).FullName; } }
		public string Namespace { get { return mMetrics.ForTypeOf(Report).Namespaces.First(); } }

        public HotspotCyclomaticComplexity(MethodMetricsReport method, MetricsReport metrics)
            : base(method)
        {
        	mMetrics = metrics;
        }
    }
}
