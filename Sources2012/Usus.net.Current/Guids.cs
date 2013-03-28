// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_Current
{
    static class GuidList
    {
        public const string guidUsus_net_CurrentPkgString = "3c97d2fc-95d1-459a-90f4-3bf200360789";
        public const string guidUsus_net_CurrentCmdSetString = "f65fdf8d-58a0-4b3e-a694-15471056beb9";
        public const string guidToolWindowPersistanceString = "8b59bcd8-3bf3-4222-98bd-908772a5a5f3";

        public static readonly Guid guidUsus_net_CurrentCmdSet = new Guid(guidUsus_net_CurrentCmdSetString);
    };
}