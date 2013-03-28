using System;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.TypeMetrics
{
    [ExpectNumberOfNonStaticPublicFields(0)]
    class ClassWithZeroNonStaticPublicFields
    {
        static int i1;
        public static int i2;
        int i3;
        public int p1 { get; set; }
        public const int i4 = 0;
    }

    [ExpectNumberOfNonStaticPublicFields(1)]
    class ClassWithOneNonStaticPublicField
    {
        static int i1;
        public static int i2;
        int i3;
        public int i4;
    }

    [ExpectNumberOfNonStaticPublicFields(1)]
    class ClassWithNonStaticPublicFields
    {
        public int i1;
    }

    class ClassWithSubClass
    {
        [ExpectNumberOfNonStaticPublicFields(2)]
        class ClassWithNonStaticPublicFields
        {
            public int i1;
            public int i2;
        }
    }
}
