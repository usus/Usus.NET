using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View;
using andrena.Usus.net.View.Hub;
using System;
using System.Runtime.InteropServices;

namespace andrena.Usus_net_TypeCylces
{
	[Guid("596808a9-ceed-4355-befe-61bdc8c7d193")]
	public class MyToolWindow : BuildAwareToolWindowPane
	{
		public MyToolWindow() :
			base(null)
		{
			this.Caption = Resources.ToolWindowTitle;
			this.BitmapResourceID = 301;
			this.BitmapIndex = 2;

			BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
			base.Content = ViewFactory.CreateTypeCycles(ViewHub.Instance);
		}
	}
}
