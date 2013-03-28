using System;
using System.Runtime.InteropServices;
using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus_net_Sqi
{
    [Guid("f5ecd2c1-f95a-4de3-9c9e-86fcbfb75164")]
    public class MyToolWindow : BuildAwareToolWindowPane, IKnowSqiDetails
    {
        public MyToolWindow() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 2;

            BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
            base.Content = ViewFactory.CreateSQI(ViewHub.Instance, this);
        }

        public double TestCoverage
        {
            get { return double.NaN; /* Automated test coverage recognition is not yet supported */ }
        }

        public int CompilerWarnings
        {
            get { return GetErrors().WarningCount; }
        }

        public string CurrentSolutionFile
        {
            get { return MasterObjekt != null ? RawSolution.FullName : null; }
        }
    }
}
