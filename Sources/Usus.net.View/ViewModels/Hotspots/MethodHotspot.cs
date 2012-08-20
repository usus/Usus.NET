using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class MethodHotspot : Hotspot<MethodMetricsReport>
    {
        public MethodHotspot(MethodMetricsReport method)
            : base(method)
        {
        }

        public override void OnDoubleClick(IJumpToSource jumper)
        {
            if (Report.SourceLocation.IsAvailable)
                jumper.JumpToFileLocation(
                    Report.SourceLocation.Filename,
                    Report.SourceLocation.Line, true);
        }
    }
}
