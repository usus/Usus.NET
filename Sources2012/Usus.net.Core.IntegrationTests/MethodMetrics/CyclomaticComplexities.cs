using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.MethodMetrics
{
    public class CyclomaticComplexities
    {
        public Object PropertyAutoImplemented
        {
            [ExpectCyclomaticComplexity(1)]
            get;

            [ExpectCyclomaticComplexity(1)]
            set;
        }

        public Object PropertyWithLogic
        {
            [ExpectCyclomaticComplexity(1)]
            get
            {
                return new NullReferenceException();
            }
            [ExpectCyclomaticComplexity(1)]
            set
            {
                value.ToString();
            }
        }

        [ExpectCyclomaticComplexity(1)]
        public static void MethodWithNothing()
        {
        }

        [ExpectCyclomaticComplexity(2)]
        public static void MethodWithIf()
        {
            bool c1 = true;
            if (c1)
                Console.WriteLine();
            else
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(6)]
        public static void MethodWithNestedIfs()
        {
            bool c1 = true;
            bool c2 = true;
            bool c3 = true;
            bool c4 = false;
            if (c1)
            {
                if (c2 && c3 || c4)
                {
                    Console.WriteLine();
                }
                else if (c4)
                {
                    Console.WriteLine();
                }
            }
        }

        [ExpectCyclomaticComplexity(2)]
        public static void MethodWithIf1Arg()
        {
            bool c1 = true;
            if (c1)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(1)]
        public static void MethodWithIfTrue()
        {
            if (true) Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(3)]
        public static void MethodWithIf2Args()
        {
            bool c1 = true;
            bool c2 = true;
            if (c1 && c2)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(4)]
        public static void MethodWithIf3Args()
        {
            bool c1 = true;
            bool c2 = true;
            bool c3 = true;
            if (c1 || c2 || c3)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(5)]
        public static void MethodWithIf4Args()
        {
            bool c1 = true;
            bool c2 = true;
            bool c3 = true;
            bool c4 = true;
            if (c1 && c2 && c3 && c4)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(5)]
        public static void MethodWithIf4ArgsCascaded()
        {
            bool c1 = true;
            bool c2 = true;
            bool c3 = true;
            bool c4 = true;
            if (c1)
                if (c2)
                    if (c3)
                        if (c4)
                            Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(9)]
        public static void MethodWith2Ifs4Args()
        {
            bool c1 = true;
            bool c2 = true;
            bool c3 = true;
            bool c4 = true;
            if (c1 && c2 && c3 || c4)
                Console.WriteLine();
            if (c1 && c2 && c3 || c4)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(2)]
        public static void MethodWithWhile()
        {
            bool c1 = true;
            while (c1)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(3)]
        public static void MethodWithWhile2Args()
        {
            bool c1 = true;
            bool c2 = true;
            while (c1 || c2)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(3)]
        public static void MethodWithWhile2Conditions()
        {
            bool c1 = true;
            bool c2 = true;
            while (c1 && c2)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(2)]
        public static void MethodWithFor()
        {
            bool c1 = true;
            for (int i = 0; c1; i++)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(3)]
        public static void MethodWithFor2Conditions()
        {
            bool c1 = true;
            bool c2 = true;
            for (int i = 0; c1 && c2; i++)
                Console.WriteLine();
        }

        [ExpectCyclomaticComplexity(3)]
        /* •———————————————————————————————————————————————•
           | Compiler creates while/if/finally statements. |
           •———————————————————————————————————————————————• */
        public static void MethodWithForeach()
        {
            foreach (var item in Enumerable.Repeat(0, 2))
                Console.WriteLine(item);
        }

        [ExpectCyclomaticComplexity(2)]
        public static IEnumerable<string> MethodWithIteratorBlocks()
        {
            yield return "";
            bool c1 = true;
            if (c1) yield return "";
        }

        [ExpectCyclomaticComplexity(1)]
        public static void MethodWithListComprehensions()
        {
            var result = from i in Enumerable.Range(0, 10)
                         from ii in Enumerable.Repeat(".", i)
                         select ii;
            var list = result.ToList();
        }

        [ExpectCyclomaticComplexity(3)]
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

        [ExpectCyclomaticComplexity(4)]
        public static void MethodWithTryCatchIf()
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
                bool c1 = true;
                if (c1)
                    Console.WriteLine();
            }
        }

        [ExpectCyclomaticComplexity(4)]
        public static void MethodWithSwitch()
        {
            int i = 3;
            switch (i)
            {
                case 1:
                    Console.WriteLine(i); break;
                case 2:
                    Console.WriteLine(i); break;
                case 3:
                    Console.WriteLine(i); break;
                default:
                    Console.WriteLine(i); break;
            }
        }

        [ExpectCyclomaticComplexity(3)]
        public static void MethodWithIfInLambda()
        {
            bool c1 = true;
            Action a = () =>
            {
                bool c2 = true;
                if (c1 && c2)
                    Console.WriteLine();
                else
                    Console.WriteLine();
            };
        }

        [ExpectCyclomaticComplexity(4)]
        public static Action MethodWithIfInAndOutLambda()
        {
            bool c1 = true;
            Action a = () =>
            {
                bool c2 = true;
                if (c1 && c2)
                    Console.WriteLine();
                else
                    Console.WriteLine();
            };
            if (c1)
                Console.WriteLine();
            return a;
        }

        [ExpectCyclomaticComplexity(2)]
        public static void MethodWithTernaryExpression()
        {
            bool c1 = true;
            Console.WriteLine(c1 ? "true!" : "false!");
        }
    }
}
