// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_Menus
{
    static class GuidList
    {
        public const string guidUsus_net_MenusPkgString = "878c3460-4336-4f49-bca9-402256be81a9";
        public const string guidUsus_net_MenusCmdSetString = "20c664c5-7165-476a-9cec-543dd3847fb0";

        public static readonly Guid guidUsus_net_MenusCmdSet = new Guid(guidUsus_net_MenusCmdSetString);
    };
}