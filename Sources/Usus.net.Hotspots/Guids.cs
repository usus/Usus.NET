// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_Hotspots
{
    static class GuidList
    {
        public const string guidUsus_net_HotspotsPkgString = "2d71d321-dddd-4c87-aade-04a68f12212d";
        public const string guidUsus_net_HotspotsCmdSetString = "ca947480-f256-476b-80a2-3f473484dc35";
        public const string guidToolWindowPersistanceString = "a6711b19-55c8-473f-a8b2-72980bfb7c70";

        public static readonly Guid guidUsus_net_HotspotsCmdSet = new Guid(guidUsus_net_HotspotsCmdSetString);
    };
}