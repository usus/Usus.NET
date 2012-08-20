using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class HotspotMethodLength : MethodHotspot
    {
        public int Length { get { return Report.MethodLength; } }
        public string Method { get { return Report.Name; } }
        public string Signature { get { return Report.Signature; } }

        public HotspotMethodLength(MethodMetricsReport method)
            : base(method)
        {
        }
    }
}
