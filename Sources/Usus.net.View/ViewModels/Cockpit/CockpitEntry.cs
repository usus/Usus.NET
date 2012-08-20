using System;
using andrena.Usus.net.Core.Helper;

namespace andrena.Usus.net.View.ViewModels.Cockpit
{
    public class CockpitEntry : ViewModel
    {
        public string Metric { get; private set; }
        public ValueInTime<double> Average { get; private set; }
        public ValueInTime<int> Total { get; private set; }
        public ValueInTime<int> Hotspots { get; private set; }
        public ValueInTime<double> Distribution { get; private set; }

        public CockpitEntry(string metric, Func<int, string> totalToString)
        {
            Metric = metric;
            Average = new ValueInTime<double>(0, d => d.Percent());
            Total = new ValueInTime<int>(0, totalToString);
            Hotspots = new ValueInTime<int>(0);
            Distribution = new ValueInTime<double>(0, d => d.Value());
        }

        public void Update(double average, int total, int hotspots, double distribution)
        {
            Average.Update(average); Changed(() => Average);
            Total.Update(total); Changed(() => Total);
            Hotspots.Update(hotspots); Changed(() => Hotspots);
            Distribution.Update(distribution); Changed(() => Distribution);
        }
    }
}
