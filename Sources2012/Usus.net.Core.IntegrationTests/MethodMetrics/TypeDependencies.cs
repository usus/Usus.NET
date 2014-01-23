using System;
using System.Collections.Generic;
using andrena.Usus.net.Core.Verification;
using System.Linq;

namespace Usus.net.Core.IntegrationTests.MethodMetrics
{
    public class TypeDependencies
    {
        public AccessViolationException PropertyAutoImplemented
        {
            [ExpectTypeDependency("System.AccessViolationException")]
            get;

            [ExpectTypeDependency("System.AccessViolationException")]
            set;
        }

        public Exception PropertyWithLogic
        {
            [ExpectTypeDependency("System.Exception")]
            [ExpectTypeDependency("System.NullReferenceException")]
            get
            {
                return new NullReferenceException();
            }
            [ExpectTypeDependency("System.Exception")]
            set
            {
                value.ToString();
            }
        }

        [ExpectTypeDependency("System.Console")]
        public static void MethodWithConsole()
        {
            Console.WriteLine("");
            Console.Write("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        [ExpectTypeDependency("System.Func")]
        [ExpectTypeDependency("System.NotFiniteNumberException")]
        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.String")]
        public static void MethodWithFunc()
        {
            Func<NotFiniteNumberException> nfne = null;
            nfne.ToString().Substring(0, 5);
        }

        [ExpectTypeDependency("System.Collections.Generic.List")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        [ExpectTypeDependency("System.Collections.Generic.IList")]
        [ExpectTypeDependency("System.ArraySegment")]
        [ExpectTypeDependency("System.String")]
        public static void MethodWithNestedGenerics()
        {
            new List<IEnumerable<IList<ArraySegment<string>>>>();
        }

        [ExpectTypeDependency("System.Collections.Generic.ICollection")]
        [ExpectTypeDependency("System.String")]
        public static void MethodWithGenericConstraints<T, R>(T t)
            where T : class
            where R : ICollection<string>
        {
            return;
        }

        [ExpectTypeDependency("System.IndexOutOfRangeException")]
        [ExpectTypeDependency("System.NotImplementedException")]
        public static void MethodWithInOutRefArgs(out NotImplementedException e1, ref IndexOutOfRangeException e2)
        {
            e1 = new NotImplementedException();
        }

        [ExpectTypeDependency("System.Exception")]
        [ExpectTypeDependency("System.NotImplementedException")]
        public static Exception MethodWithNoGenericsInSignature(NotImplementedException e)
        {
            return e;
        }

        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.Collections.Generic.List")]
        [ExpectTypeDependency("System.Collections.Generic.IList")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        [ExpectTypeDependency("System.NotImplementedException")]
        public static IList<Object> MethodWithGenericsInSignature(IEnumerable<NotImplementedException> e)
        {
            return new List<Object>();
        }

        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.Collections.Generic.List")]
        [ExpectTypeDependency("System.Collections.Generic.IList")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        public static IEnumerable<IList<Object>> MethodWithNestedGenericsInSignature()
        {
            return new List<List<Object>>();
        }

        [ExpectNoTypeDependency("System.Object")]
        public static void MethodWithNoObject()
        {
            return;
        }

        [ExpectTypeDependency("System.NotImplementedException")]
        [ExpectTypeDependency("System.NotFiniteNumberException")]
        public static void MethodWithTryCatch()
        {
            try
            {
                Console.WriteLine();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine();
            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine();
            }
        }

        [ExpectTypeDependency("System.Exception")]
        [ExpectTypeDependency("System.Collections.Generic.List")]
        public static void MethodWithArrayOfLists()
        {
            var exceptions = new List<Exception>[0];
        }

        [ExpectTypeDependency("System.Exception")]
        [ExpectTypeDependency("System.Collections.Generic.List")]
        public static void MethodWithListArrays()
        {
            var exceptions = new List<Exception[]>();
        }

        [ExpectTypeDependency("System.Linq.Enumerable")]
        [ExpectTypeDependency("System.Exception")]
        public static void MethodWithGenericCall()
        {
            var ints = new int[0];
            ints.Cast<Exception>();
        }

        [ExpectTypeDependency("System.FieldAccessException")]
        [ExpectTypeDependency("System.NotImplementedException")]
        public static void MethodWithCasts()
        {
            object o1 = (NotImplementedException)new object();
            o1.ToString();
            object o2 = new object() as FieldAccessException;
            o2.ToString();
        }

        [ExpectTypeDependency("System.FieldAccessException")]
        [ExpectTypeDependency("System.NotImplementedException")]
        public static void MethodWithTypeOfs()
        {
            object o1 = typeof(FieldAccessException);
            object o2 = new object() is NotImplementedException;
        }

        enum SampleEnum { One, Two }
        [ExpectTypeDependency("Usus.net.Core.IntegrationTests.MethodMetrics.TypeDependencies.SampleEnum")]
        public static void MethodWithEnumReference()
        {
            object dt = SampleEnum.One;
        }

        class SampleEventClass { public static event Action<Exception> SampleEvent; }
        [ExpectTypeDependency("Usus.net.Core.IntegrationTests.MethodMetrics.TypeDependencies.SampleEventClass")]
        public static void MethodWithEventReference()
        {
            SampleEventClass.SampleEvent += (e) => { };
        }

        [ExpectNoTypeDependency("System.Object")]
        /* •—————————————————————————————————————————————————————————————————————————————————————•
           | Lambdas are compiler generated fields with delegates to compiler generated methods. |
           | Their types will be recognized by method and field aggregation.                     |
           •—————————————————————————————————————————————————————————————————————————————————————• */
        public static void MethodWithLambda()
        {
            Action a = () => object.Equals(null, null);
        }

        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        [ExpectNoTypeDependency("System.NotImplementedException")]
        /* •——————————————————————————————————————————————————————————————————————•
           | Iterators are compiler generated sub classes.                        |
           | Their types will be recognized by cumulative dependency aggregation. |
           •——————————————————————————————————————————————————————————————————————• */
        public static IEnumerable<Object> MethodWithYieldReturn()
        {
            yield return new NotImplementedException();
        }
    }
}
