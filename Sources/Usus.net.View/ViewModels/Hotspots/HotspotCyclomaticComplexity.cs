using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotCyclomaticComplexity : MethodHotspot
    {
        public int Complexity { get { return Report.CyclomaticComplexity; } }
        public string Method { get { return Report.Name; } }
        public string Signature { get { return Report.Signature; } }

        public HotspotCyclomaticComplexity(MethodMetricsReport method)
            : base(method)
        {
        }
    }
}
