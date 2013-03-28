using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.SQI
{
    public static class Calculate
    {
        public static double SoftwareQualityIndex(this IParameterProvider parameters)
        {
            var cachedParameters = new CachedParameters(parameters);
            var metrics = cachedParameters.CalculateAllSqiMetrics().ToList();
            return metrics.Sum();
        }

        private static IEnumerable<double> CalculateAllSqiMetrics(this IParameterProvider parameters)
        {
            yield return 0.1 * 2.28 * CalculateTestCoverage(parameters);
            yield return 0.1 * 1.93 * CalculateNamespacesInCycles(parameters);
            yield return 0.1 * 1.75 * CalculateCompilcatedMethods(parameters);
            yield return 0.1 * 1.58 * CalculateAcd(parameters);
            yield return 0.1 * 1.05 * CalculateBigClasses(parameters);
            yield return 0.1 * 1.05 * CalculateBigMethods(parameters);
            yield return 0.1 * 0.36 * CalculateCompilerWarnings(parameters);
        }

        private static double CalculateCompilerWarnings(IParameterProvider parameters)
        {
            return parameters.SqNiveau(m => m.CompilerWarnings, Sqi.RelativeCompilerWarnings, Sqi.CalibrationCompilerWarnings);
        }

        private static double CalculateBigMethods(IParameterProvider parameters)
        {
            return parameters.SqNiveau(m => m.BigMethods, Sqi.RelativeSizeBigMethods, Sqi.CalibrationBigMethods) 
                * parameters.SqNiveauCorrection(m => m.BigMethods, Sqi.MiddleSizeBigMethods, Sqi.CorrectionBigMethods);
        }

        private static double CalculateBigClasses(IParameterProvider parameters)
        {
            return parameters.SqNiveau(m => m.BigClasses, Sqi.RelativeSizeBigClasses, Sqi.CalibrationBigClasses) 
                * parameters.SqNiveauCorrection(m => m.BigClasses, Sqi.MiddleSizeBigClasses, Sqi.CorrectionBigClasses);
        }

        private static double CalculateAcd(IParameterProvider parameters)
        {
            return parameters.SqNiveau(m => m.AverageComponentDependency, Sqi.RelativeSizeAcd, Sqi.CalibrationAcd)
                * parameters.SqNiveauCorrection(m => m.AverageComponentDependency, Sqi.MiddleSizeAcd, Sqi.CorrectionAcd);
        }

        private static double CalculateCompilcatedMethods(IParameterProvider parameters)
        {
            return parameters.SqNiveau(m => m.ComplicatedMethods, Sqi.RelativeSizeComplicatedMethods, Sqi.CalibrationComplicatedMethods)
                * parameters.SqNiveauCorrection(m => m.ComplicatedMethods, Sqi.MiddleSizeComplicatedMethods, Sqi.CorrectionComplicatedMethods);
        }

        private static double CalculateNamespacesInCycles(IParameterProvider parameters)
        {
            return parameters.SqNiveau(m => m.NamespaceCycles, Sqi.RelativeSizeNamespacesInCycles, Sqi.CalibrationNamespacesInCycles) 
                * parameters.SqNiveauCorrection(m => m.NamespaceCycles, Sqi.MiddleSizeNamespacesInCycles, Sqi.CorrectionNamespacesInCycles);
        }

        private static double CalculateTestCoverage(IParameterProvider parameters)
        {
            return parameters.TestCoverage;
        }
    }
}
