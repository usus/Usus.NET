// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_CleanCode
{
    static class GuidList
    {
        public const string guidUsus_net_CleanCodePkgString = "b46ffb70-45a2-43ea-894d-935951f0167e";
        public const string guidUsus_net_CleanCodeCmdSetString = "a51a44e6-820c-4c92-a992-267c8f58ed0c";
        public const string guidToolWindowPersistanceString = "7b1fb922-8f25-467b-b18f-ec6bad59389d";

        public static readonly Guid guidUsus_net_CleanCodeCmdSet = new Guid(guidUsus_net_CleanCodeCmdSetString);
    };
}