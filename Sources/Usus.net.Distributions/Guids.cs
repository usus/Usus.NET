// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_Distributions
{
    static class GuidList
    {
        public const string guidUsus_net_DistributionsPkgString = "c93eb0d8-9e3a-4ba8-a92b-f2d472afda5f";
        public const string guidUsus_net_DistributionsCmdSetString = "e882a31a-7d72-4ef6-8da5-e1c26af520cb";
        public const string guidToolWindowPersistanceString = "37be7669-86ba-44f0-88ba-0736a2739377";

        public static readonly Guid guidUsus_net_DistributionsCmdSet = new Guid(guidUsus_net_DistributionsCmdSetString);
    };
}