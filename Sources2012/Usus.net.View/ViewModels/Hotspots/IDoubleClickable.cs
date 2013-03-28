
namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public interface IDoubleClickable<T> where T : class
    {
        void OnDoubleClick(T t);
    }
}
