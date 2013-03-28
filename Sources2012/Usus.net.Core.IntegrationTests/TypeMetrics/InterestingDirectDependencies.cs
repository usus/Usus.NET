using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.TypeMetrics
{
    class InterestingDirectDependencies
    {
        [ExpectDirectDependency("System.Object")]
        [ExpectNoInterestingDirectDependency("System.Object")]
        class ClassWithObject
        { }

        [ExpectInterestingDirectDependency("Usus.net.Core.IntegrationTests.TypeMetrics.InterestingDirectDependencies.ClassWithObject")]
        class ClassWithClassWithObject
        {
            ClassWithObject f;
        }
    }
}
