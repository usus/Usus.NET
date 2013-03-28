using System;
using System.Runtime.InteropServices;
using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus_net_Cockpit
{
    [Guid("e010d073-2f82-415b-beaa-bfa1655fcdb0")]
    public class MyToolWindow : BuildAwareToolWindowPane, IJumpToSource
    {
        public MyToolWindow() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 2;

            BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
            base.Content = ViewFactory.CreateCockpit(ViewHub.Instance, this);
        }

        public void JumpToFileLocation(string path, int line, bool selection)
        {
            OpenFileAtLine(path, line, selection);
        }
    }
}
