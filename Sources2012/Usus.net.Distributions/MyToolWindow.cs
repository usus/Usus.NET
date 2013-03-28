using System;
using System.Runtime.InteropServices;
using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus_net_Distributions
{
    [Guid("37be7669-86ba-44f0-88ba-0736a2739377")]
    public class MyToolWindow : BuildAwareToolWindowPane
    {
        public MyToolWindow() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 2;

            BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
            base.Content = ViewFactory.CreateDistributions(ViewHub.Instance);
        }
    }
}
