using MathNet.Numerics.Statistics;

namespace andrena.Usus.net.Core.Math
{
    public class GeometricalDistributionFitting : IFittingReport
    {
        Histogram histogram;
        DescriptiveStatistics statistics;

        public GeometricalDistributionFitting(Histogram histogram)
        {
            this.histogram = histogram;
            statistics = new DescriptiveStatistics(histogram.Numbers);
        }

        public double Parameter
        {
            get { return System.Math.Min(1.0, 1.0 / statistics.Mean); }
        }

        public double Error
        {
            //TODO: sum of squared errors? chi squared?
            get { throw new System.NotImplementedException(); }
        }
    }
}
