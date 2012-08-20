using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Math
{
    public class Distribution
    {
        IEnumerable<int> JustZero = Enumerable.Range(0, 1);

        public Histogram Histogram { get; private set; }
        public IFittingReport GeometricalFit { get; private set; }

        public Distribution(IEnumerable<int> data)
        {
            if (data.Any()) 
                Histogram = new Histogram(data);
            else
                Histogram = new Histogram(JustZero);
            GeometricalFit = new GeometricalDistributionFitting(Histogram);
        }
    }
}
