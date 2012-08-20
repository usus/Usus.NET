using System;
using andrena.Usus.net.View.ViewModels.Current;

namespace andrena.Usus_net_Current
{
    public class LocationPush
    {
        Action<LineLocation> pushHandler;

        internal LocationPush()
        { }

        public void RegisterHandler(Action<LineLocation> handler)
        {
            pushHandler = handler;
        }

        internal void Push(LineLocation location)
        {
            if (pushHandler != null && location != null) pushHandler(location);
        }
    }
}
