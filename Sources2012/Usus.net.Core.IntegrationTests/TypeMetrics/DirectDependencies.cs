using System;
using System.Collections.Generic;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.TypeMetrics
{
    class DirectDependencies
    {
        [ExpectDirectDependency("Usus.net.Core.IntegrationTests.TypeMetrics.DirectDependencies.SimpleClass")]
        class SimpleClass
        { }

        [ExpectDirectDependency("Usus.net.Core.IntegrationTests.TypeMetrics.DirectDependencies.SimpleClass")]
        class GenericClass<T> where T : SimpleClass
        { }

        [ExpectDirectDependency("Usus.net.Core.IntegrationTests.TypeMetrics.DirectDependencies.SimpleClass")]
        class GenericClass<T, R>
            where T : SimpleClass
            where R : SimpleClass
        { }

        [ExpectNoDirectDependency("System.Exception")]
        class ClassWithoutBase
        { }

        [ExpectDirectDependency("System.Exception")]
        class ClassWithBase : Exception
        { }

        [ExpectDirectDependency("System.Exception")]
        [ExpectDirectDependency("System.ICloneable")]
        [ExpectDirectDependency("System.NotImplementedException")]
        class ClassWithBaseAndInterface : Exception, ICloneable
        {
            public object Clone()
            {
                throw new NotImplementedException();
            }
        }

        [ExpectDirectDependency("System.Exception")]
        [ExpectDirectDependency("System.Action")]
        [ExpectDirectDependency("System.Func")]
        [ExpectDirectDependency("System.Nullable")]
        [ExpectDirectDependency("System.Double")]
        [ExpectDirectDependency("System.NotSupportedException")]
        [ExpectDirectDependency("System.NotImplementedException")]
        class ClassWithField
        {
            Exception f;
            Action<NotSupportedException[]> a;
            event Func<Nullable<double>[]> e;
            object o = new NotImplementedException();
        }

        [ExpectDirectDependency("System.Exception")]
        class ClassWithLambda
        {
            public void m()
            {
                Action a = () => new Exception(null, null);
            }
        }

        [ExpectDirectDependency("System.Exception")]
        [ExpectNoDirectDependency("System.NotSupportedException")]
        [ExpectNoDirectDependency("System.NotImplementedException")]
        /* •——————————————————————————————————————————————————————————————————————•
           | Iterators are compiler generated sub classes.                        |
           | Their types will be recognized by cumulative dependency aggregation. |
           •——————————————————————————————————————————————————————————————————————• */
        class ClassWithIterator
        {
            private IEnumerable<Exception> m()
            {
                yield return new NotSupportedException();
                yield return new NotImplementedException();
            }
        }
    }
}
