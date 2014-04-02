// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_Graphs
{
    static class GuidList
    {
        public const string guidUsus_net_GraphsPkgString = "e8f66024-70e6-46f4-90f9-ea658525bb39";
        public const string guidUsus_net_GraphsCmdSetString = "c133a123-a5a5-4e6e-b2ee-c175b8c5caec";
        public const string guidToolWindowPersistanceString = "4cb4517c-e20d-497b-ad21-40b03fa977d6";

        public static readonly Guid guidUsus_net_GraphsCmdSet = new Guid(guidUsus_net_GraphsCmdSetString);
    };
}