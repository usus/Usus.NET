using System;
using System.Runtime.InteropServices;
using andrena.Usus.net.View;
using Microsoft.VisualStudio.Shell;

namespace andrena.Usus_net_CleanCode
{
    [Guid("7b1fb922-8f25-467b-b18f-ec6bad59389d")]
    public class MyToolWindow : ToolWindowPane
    {
        public MyToolWindow() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 2;

            base.Content = new CleanCode();
        }
    }
}
