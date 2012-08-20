using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public abstract class Hotspot<T> : IDoubleClickable<IJumpToSource> where T : class
    {
        protected T Report { get; private set; }

        public Hotspot(T report)
        {
            Report = report;
        }

        public virtual void OnDoubleClick(IJumpToSource jumper)
        {
        }
    }
}
