namespace Usus.net.Core.IntegrationTests.NamespaceMetrics
{
    namespace Test1
    {
        public class Class1 { }
    }
    namespace Test2
    {
        public class Class2 { }
    }
    namespace Test3
    {
        public class Class3 { }
    }

    namespace Test4
    {
        class Class4 {
            object c = new Test5.Class5();
        }
    }
    namespace Test5
    {
        class Class5 {
            object c = new Test6.Class6();
        }
    }
    namespace Test6
    {
        class Class6 {
            object c = new Test4.Class4();
        }
    }
}
