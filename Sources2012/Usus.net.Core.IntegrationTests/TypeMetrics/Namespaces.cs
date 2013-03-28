using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.TypeMetrics
{
    [ExpectNamespace("Usus")]
    [ExpectNamespace("Usus.net")]
    [ExpectNamespace("Usus.net.Core")]
    [ExpectNamespace("Usus.net.Core.IntegrationTests")]
    [ExpectNamespace("Usus.net.Core.IntegrationTests.TypeMetrics")]
    class Namespaces
    {
        [ExpectNamespace("Usus")]
        [ExpectNamespace("Usus.net")]
        [ExpectNamespace("Usus.net.Core")]
        [ExpectNamespace("Usus.net.Core.IntegrationTests")]
        [ExpectNamespace("Usus.net.Core.IntegrationTests.TypeMetrics")]
        class InnerClass
        {
            [ExpectNamespace("Usus")]
            [ExpectNamespace("Usus.net")]
            [ExpectNamespace("Usus.net.Core")]
            [ExpectNamespace("Usus.net.Core.IntegrationTests")]
            [ExpectNamespace("Usus.net.Core.IntegrationTests.TypeMetrics")]
            class InnerInnerClass
            {
            }
        }
    }
}
