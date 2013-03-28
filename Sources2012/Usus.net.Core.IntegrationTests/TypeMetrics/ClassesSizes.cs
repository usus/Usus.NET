using System;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.TypeMetrics
{
    [ExpectNumberOfMethods(0)]
    class ClassWithZeroMethods
    {
        static int i1;
        public static int i2;
        int i3;
    }

    [ExpectNumberOfMethods(1)]
    class ClassWithOneMethod
    {
        static int i1;
        public static int i2;
        int i3;
        public void m() { }
    }

    [ExpectNumberOfMethods(2)]
    class ClassWithOneMethodOneStatic
    {
        public int i1;
        public void m1() { }
        public static void m2() { }
    }

    [ExpectNumberOfMethods(1)]
    class ClassWithMethods
    {
        public int i1;
        public void m() { }
    }

    class ClassWithSubClassAndMethods
    {
        [ExpectNumberOfMethods(2)]
        class ClassWithMethods
        {
            public void m1() { }
            public void m2() { }
        }
    }

    [ExpectNumberOfMethods(0)]//default ctor does not count
    class ClassDefaultCtor
    {
        public int i1;
        public ClassDefaultCtor() { }
    }

    [ExpectNumberOfMethods(1)]
    class ClassNonDefaultCtor
    {
        public int i1;
        public ClassNonDefaultCtor(int i) { }
    }

    [ExpectNumberOfMethods(2)]
    static class StaticClassOneMethodAndCctor
    {
        static StaticClassOneMethodAndCctor() {}
        public static void m1() { }
    }

    [ExpectNumberOfMethods(2)]
    class ClassWithGetterSetter
    {
        public int p1 { get; set; }
    }

    [ExpectNumberOfMethods(1)]
    class ClassWithGetter
    {
        int i1;
        public int p1 { get { return i1; } }
    }
}
