// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_Cockpit
{
    static class GuidList
    {
        public const string guidUsus_net_CockpitPkgString = "e6a2f749-5fd9-4ade-a33e-02f5d4945c61";
        public const string guidUsus_net_CockpitCmdSetString = "69e66ffd-3425-423d-879e-3260a7619afa";
        public const string guidToolWindowPersistanceString = "e010d073-2f82-415b-beaa-bfa1655fcdb0";

        public static readonly Guid guidUsus_net_CockpitCmdSet = new Guid(guidUsus_net_CockpitCmdSetString);
    };
}