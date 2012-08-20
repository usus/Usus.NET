using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using andrena.Usus.net.ExtensionHelper;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace andrena.Usus_net_Menus
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidUsus_net_MenusPkgString)]
    public sealed class Usus_net_MenusPackage : Package
    {
        public Usus_net_MenusPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            _Shell = GetService(typeof(SVsShell)) as IVsShell;
            if (null != mcs)
            {
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetCockpit, MenuItemCallback_Cockpit);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetHotspots, MenuItemCallback_Hotspots);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetDistributions, MenuItemCallback_Distributions);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetCleanCode, MenuItemCallback_CleanCode);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetCurrent, MenuItemCallback_Current);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetSqi, MenuItemCallback_Sqi);
            }
        }

        private static void SetupCommand(OleMenuCommandService mcs, uint cmdId, EventHandler cmdCallback)
        {
            CommandID menuCommandID = new CommandID(GuidList.guidUsus_net_MenusCmdSet, (int)cmdId);
            MenuCommand menuItem = new MenuCommand(cmdCallback, menuCommandID);
            mcs.AddCommand(menuItem);
        }

        IVsShell _Shell;

        private void MenuItemCallback_Cockpit(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Cockpit);
        }

        private void MenuItemCallback_Hotspots(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Hotspots);
        }

        private void MenuItemCallback_Distributions(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Distributions);
        }

        private void MenuItemCallback_CleanCode(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.CleanCode);
        }

        private void MenuItemCallback_Current(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Current);
        }

        private void MenuItemCallback_Sqi(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Sqi);
        }
    }
}
