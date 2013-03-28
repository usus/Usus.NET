using System;
using System.Runtime.InteropServices;
using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus_net_Hotspots
{
    [Guid("a6711b19-55c8-473f-a8b2-72980bfb7c70")]
    public class MyToolWindow : BuildAwareToolWindowPane, IJumpToSource
    {
        public MyToolWindow() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 2;

            BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
            base.Content = ViewFactory.CreateHotspots(ViewHub.Instance, this);
        }

        public void JumpToFileLocation(string path, int line, bool selection)
        {
            OpenFileAtLine(path, line, selection);
        }
    }
}
