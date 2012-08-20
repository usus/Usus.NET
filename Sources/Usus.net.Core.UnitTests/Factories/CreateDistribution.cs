using System;
using System.Linq;
using andrena.Usus.net.Core.Math;
using andrena.Usus.net.Core.Reports;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests.Factories
{
    public static class CreateDistribution
    {
        public static Distribution ForMethods(Func<MethodMetricsReport, int> selector, params MethodMetricsReport[] methods)
        {
            var report = Create.MetricsReport(methods);
            return report.MethodDistribution(selector);
        }

        public static Distribution ForTypes(Func<TypeMetricsReport, int> selector, params TypeMetricsReport[] methods)
        {
            var report = Create.MetricsReport(methods);
            return report.TypeDistribution(selector);
        }

        public static Distribution ForMethodLengths(params int[] methodLengths)
        {
            return ForMethods(m => m.MethodLength, methodLengths.Select(m => MethodReport(m, 1)).ToArray());
        }

        public static Distribution ForPublicFields(params int[] publicFieldsLengths)
        {
            return ForTypes(m => m.NumberOfNonStaticPublicFields, publicFieldsLengths.Select(m => TypeReport(m)).ToArray());
        }

        private static MethodMetricsReport MethodReport(int methodLength, int cyclomaticComplexity)
        {
            return new MethodMetricsReport
            {
                CyclomaticComplexity = cyclomaticComplexity,
                NumberOfLogicalLines = methodLength
            };
        }

        private static TypeMetricsReport TypeReport(int publicfields)
        {
            return new TypeMetricsReport
            {
                FullName = Create.RandomName(),
                NumberOfNonStaticPublicFields = publicfields
            };
        }
    }
}
