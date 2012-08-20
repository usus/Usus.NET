using System;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.MethodMetrics
{
    class AbstractTypes
    {
        interface IInterface
        {
            [ExpectNumberOfLogicalLines(0)]
            [ExpectNumberOfRealLines(0)]
            [ExpectTypeDependency("System.Exception")]
            [ExpectTypeDependency("System.NullReferenceException")]
            [ExpectCyclomaticComplexity(0)]
            NullReferenceException DoSomething(Exception e);
        }

        abstract class IAbstractClass
        {
            [ExpectNumberOfLogicalLines(0)]
            [ExpectNumberOfRealLines(0)]
            [ExpectTypeDependency("System.Exception")]
            [ExpectTypeDependency("System.NullReferenceException")]
            [ExpectCyclomaticComplexity(0)]
            public abstract NullReferenceException DoSomething(Exception e);
        }
    }
}
