using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.MethodMetrics
{
    public class MethodLengths
    {
        public static Object PropertyAutoImplemented
        {
            [ExpectNumberOfLogicalLines(0)]
            [ExpectNumberOfRealLines(0)]
            [ExpectNumberOfStatements(0)]
            get;

            [ExpectNumberOfLogicalLines(0)]
            [ExpectNumberOfRealLines(0)]
            [ExpectNumberOfStatements(0)]
            set;
        }

        public static Object PropertyWithLogic
        {
            [ExpectNumberOfLogicalLines(2)]
            [ExpectNumberOfRealLines(1)]
            [ExpectNumberOfStatements(1)]
            get
            {
                return new NullReferenceException();
            }

            [ExpectNumberOfLogicalLines(1)]
            [ExpectNumberOfRealLines(1)]
            [ExpectNumberOfStatements(1)]
            set
            {
                value.ToString();
            }
        }

        public static Object PropertyGetterWithLogic
        {
            [ExpectNumberOfLogicalLines(2)]
            [ExpectNumberOfRealLines(1)]
            [ExpectNumberOfStatements(1)]
            get
            {
                return new NullReferenceException();
            }
        }

        [ExpectNumberOfLogicalLines(0)]
        [ExpectNumberOfRealLines(0)]
        [ExpectNumberOfStatements(0)]
        private void MethodWithNoLines_PrivateInstance()
        {
        }

        [ExpectNumberOfStatements(1)]
        private bool MethodWithJustReturn()
        {
            return true;
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(3)]
        [ExpectNumberOfStatements(3)]
        public static void MethodWithThreeLines()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(5)]
        [ExpectNumberOfStatements(3)]
        public static void MethodWithThreeLinesTwoEmtpyLines()
        {
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(5)]
        [ExpectNumberOfStatements(3)]
        public static void MethodWithStatementInIfBlock()
        {
            bool c1 = true;
            if (c1)
            {
                Console.WriteLine();
            }
        }

        [ExpectNumberOfStatements(3)]
        public static void MethodWithStatementInIf()
        {
            bool c1 = true;
            if (c1) Console.WriteLine();
        }

        [ExpectNumberOfStatements(4)]
        /* •———————————————————————————————————————————————•
           | Compiler creates while/if/finally statements. |
           •———————————————————————————————————————————————• */
        public static void MethodWithForeach()
        {
            foreach (var item in Enumerable.Repeat(0, 2))
                Console.WriteLine(item);
        }

        [ExpectNumberOfLogicalLines(-1)]
        [ExpectNumberOfRealLines(-1)]
        [ExpectNumberOfStatements(4)]
        /* •——————————————————————————————————————————————————•
           | Iterators don't have operation locations in pdb. |
           •——————————————————————————————————————————————————• */
        public static IEnumerable<string> MethodWithIteratorBlocks()
        {
            yield return "";
            bool c1 = true;
            if (c1) yield return "";
        }

        [ExpectNumberOfLogicalLines(2)]
        [ExpectNumberOfRealLines(4)]
        [ExpectNumberOfStatements(4)]
        public static void MethodWithListComprehensions()
        {
            var result = from i in Enumerable.Range(0, 10)
                         from ii in Enumerable.Repeat(".", i)
                         select ii;
            var list = result.ToList();
        }
    }
}
