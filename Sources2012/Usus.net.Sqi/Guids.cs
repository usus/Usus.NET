// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_Sqi
{
    static class GuidList
    {
        public const string guidUsus_net_SqiPkgString = "7e2072fe-9fb5-4cc3-b968-44be201b0654";
        public const string guidUsus_net_SqiCmdSetString = "5f4e3c61-b2f9-48e3-8cfa-423a34cc0c52";
        public const string guidToolWindowPersistanceString = "f5ecd2c1-f95a-4de3-9c9e-86fcbfb75164";

        public static readonly Guid guidUsus_net_SqiCmdSet = new Guid(guidUsus_net_SqiCmdSetString);
    };
}