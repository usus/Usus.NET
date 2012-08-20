using andrena.Usus.net.Core.Verification;
using System.Collections.Generic;

namespace Usus.net.Core.IntegrationTests.TypeMetrics
{
    class CumulativeComponentDependencies
    {
        [ExpectCumulativeComponentDependency(1)]
        class ClassNoInterestingDependencies
        { }
     
        [ExpectCumulativeComponentDependency(2)]
        class ClassInterestingDependenciesA : ClassNoInterestingDependencies
        { }

        [ExpectCumulativeComponentDependency(2)]
        class ClassInterestingDependenciesB : ClassNoInterestingDependencies
        { }

        [ExpectCumulativeComponentDependency(3)]
        class ClassInterestingDependenciesAA : ClassInterestingDependenciesA
        {
            ClassNoInterestingDependencies f;
        }

        [ExpectCumulativeComponentDependency(3)]
        class ClassInterestingDependenciesAB : ClassInterestingDependenciesA
        {
            ClassNoInterestingDependencies f1;
            ClassInterestingDependenciesA f2;
        }

        [ExpectCumulativeComponentDependency(4)]
        class ClassInterestingDependenciesAB2 : ClassInterestingDependenciesA
        {
            ClassNoInterestingDependencies f1;
            ClassInterestingDependenciesB f2;
        }

        [ExpectCumulativeComponentDependency(3)]
        class ClassWitIteratorDependencies
        {
            IEnumerable<ClassNoInterestingDependencies> m()
            {
                yield return new ClassInterestingDependenciesA();
            }
        }
    }
}
