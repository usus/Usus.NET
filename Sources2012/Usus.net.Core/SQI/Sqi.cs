using System;

namespace andrena.Usus.net.Core.SQI
{
    internal static class Sqi
    {
        internal delegate double RelativeSize(double metric, IParameterProvider parameters);
        internal readonly static RelativeSize RelativeSizeNamespacesInCycles = (m, p) => m / p.Namespaces;
        internal readonly static RelativeSize RelativeSizeComplicatedMethods = (m, p) => m / p.Methods;
        internal readonly static RelativeSize RelativeSizeAcd = (m, p) => m;
        internal readonly static RelativeSize RelativeSizeBigClasses = (m, p) => m / p.Classes;
        internal readonly static RelativeSize RelativeSizeBigMethods = (m, p) => m / p.Methods;
        internal readonly static RelativeSize RelativeCompilerWarnings = (m, p) => m / p.Classes;

        internal delegate double Calibration(double metric, IParameterProvider parameters);
        internal readonly static Calibration CalibrationNamespacesInCycles = (m, p) => 1.0 / 15;
        internal readonly static Calibration CalibrationComplicatedMethods = (m, p) => 1.0 / 50;
        internal readonly static Calibration CalibrationAcd = (m, p) => 100 * System.Math.Pow(p.Classes, -1.0 / 3);
        internal readonly static Calibration CalibrationBigClasses = (m, p) => 1.0 / 25;
        internal readonly static Calibration CalibrationBigMethods = (m, p) => 1.0 / 25;
        internal readonly static Calibration CalibrationCompilerWarnings = (m, p) => 1.0 / 50;

        internal static double SqNiveau(this IParameterProvider parameters, Func<IParameterProvider, double> metric, RelativeSize relativeSize, Calibration calibration)
        {
            return 100.0 / System.Math.Pow(1.5, relativeSize(metric(parameters), parameters) / calibration(metric(parameters), parameters));
        }

        internal delegate double MiddleSize(double metric, IParameterProvider parameters);
        internal readonly static MiddleSize MiddleSizeNamespacesInCycles = (m, p) => 1.0 * p.Rloc / p.Namespaces;
        internal readonly static MiddleSize MiddleSizeComplicatedMethods = (m, p) => 1.0 * p.Rloc / p.Methods;
        internal readonly static MiddleSize MiddleSizeAcd = (m, p) => 1.0 * p.Rloc / p.Classes;
        internal readonly static MiddleSize MiddleSizeBigClasses = (m, p) => 1.0 * p.Rloc / p.Classes;
        internal readonly static MiddleSize MiddleSizeBigMethods = (m, p) => 1.0 * p.Rloc / p.Methods;

        internal delegate double CorrectionCalibration(double metric, IParameterProvider parameters);
        internal readonly static CorrectionCalibration CorrectionNamespacesInCycles = (m, p) => 3000;
        internal readonly static CorrectionCalibration CorrectionComplicatedMethods = (m, p) => 15;
        internal readonly static CorrectionCalibration CorrectionAcd = (m, p) => 200;
        internal readonly static CorrectionCalibration CorrectionBigClasses = (m, p) => 200;
        internal readonly static CorrectionCalibration CorrectionBigMethods = (m, p) => 15;

        internal static double SqNiveauCorrection(this IParameterProvider parameters, Func<IParameterProvider, double> metric, MiddleSize middleSize, CorrectionCalibration calibration)
        {
            return 1.0 / System.Math.Pow(1.5, System.Math.Pow(middleSize(metric(parameters), parameters) / calibration(metric(parameters), parameters), 3.0));
        }
    }
}
