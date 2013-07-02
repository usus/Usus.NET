using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View;
using andrena.Usus.net.View.Hub;
using System;
using System.Runtime.InteropServices;

namespace andrena.Usus_net_Graphs
{
	[Guid("4cb4517c-e20d-497b-ad21-40b03fa977d6")]
	public class MyToolWindow : BuildAwareToolWindowPane
	{
		public MyToolWindow() :
			base(null)
		{
			this.Caption = Resources.ToolWindowTitle;
			this.BitmapResourceID = 301;
			this.BitmapIndex = 2;

			BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
			base.Content = ViewFactory.CreateGraphs(ViewHub.Instance);
		}
	}
}
