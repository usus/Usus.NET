using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace andrena.Usus_net_Cockpit
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [CLSCompliant(false), ComVisible(true)]
    public class OptionPane : DialogPage
    {
        bool parallelAnalysis = false;

        [Category("Usus.NET")]
        [DisplayName("Analyze in parallel")]
        [Description("When his value is set to True, the build analysis of the projects in the solution is parallelized using all available processor cores. When it is set to False, the analysis will not be parallelized.")]
        public bool ParallelizedAnalysis
        {
            get { return parallelAnalysis; }
            set { parallelAnalysis = value; }
        }
    }
}
