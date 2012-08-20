using System.Collections.Generic;
using MathNet.Numerics.Statistics;
using MathNetHistogram = MathNet.Numerics.Statistics.Histogram;

namespace andrena.Usus.net.Core.Math
{
    internal static class HistogramExtensions
    {
        public static MathNetHistogram AddBuckets(this MathNetHistogram histogram, IEnumerable<Bucket> buckets)
        {
            foreach (var bucket in buckets)
            {
                histogram.AddBucket(bucket);
            }
            return histogram;
        }
    }
}