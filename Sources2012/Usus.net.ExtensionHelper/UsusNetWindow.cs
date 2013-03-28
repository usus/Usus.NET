using System;
using Microsoft.VisualStudio.Shell.Interop;

namespace andrena.Usus.net.ExtensionHelper
{
    public static class UsusNetWindow
    {
        public readonly static string Sqi = "7e2072fe-9fb5-4cc3-b968-44be201b0654";
        public readonly static string Current = "3c97d2fc-95d1-459a-90f4-3bf200360789";
        public readonly static string Cockpit = "e6a2f749-5fd9-4ade-a33e-02f5d4945c61";
        public readonly static string Hotspots = "2d71d321-dddd-4c87-aade-04a68f12212d";
        public readonly static string Distributions = "c93eb0d8-9e3a-4ba8-a92b-f2d472afda5f";
        public readonly static string CleanCode = "b46ffb70-45a2-43ea-894d-935951f0167e";

        public static void Open(IVsShell shell, string guid)
        {
            Open(shell, guid, null);
        }
        
        public static void Open(IVsShell shell, string guid, object parameter)
        {
            if (shell == null) return;
            LoadPackage(shell, guid);
            GlobalEventManager.Instance.FireEvent(guid, parameter);
        }

        private static void LoadPackage(IVsShell shell, string guid)
        {
            IVsPackage package = null;
            Guid PackageToBeLoadedGuid = new Guid(guid);
            shell.LoadPackage(ref PackageToBeLoadedGuid, out package);
        }
    }
}
