using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;
using MathNetHistogram = MathNet.Numerics.Statistics.Histogram;

namespace andrena.Usus.net.Core.Math
{
    public class Histogram
    {
        private MathNetHistogram _histogram;
        private readonly IEnumerable<int> _numbers;

        public Histogram(IEnumerable<int> numbers)
        {
            _numbers = numbers;
            FillHistogram();
        }

        private void FillHistogram()
        {
            _histogram = new MathNetHistogram();
            _histogram.AddBuckets(For(Numbers)).AddData(Numbers);
        }

        private static IEnumerable<Bucket> For(IEnumerable<double> numbers)
        {
            var biggestNumber = (int)numbers.Max() + 1;
            return Enumerable.Range(0, biggestNumber)
                .Select(BucketWithTolerance);
        }

        private static Bucket BucketWithTolerance(int number)
        {
            const double tolerance = 0.5d;
            return new Bucket(number - tolerance, number + tolerance);
        }

        public int BinCount
        {
            get { return _histogram.BucketCount; }
        }

        public double ElementsInBin(int index)
        {
            return _histogram[index].Count;
        }

        public IEnumerable<double> Numbers
        {
            get { return _numbers.Select(number => (double)number); }
        }
    }
}
