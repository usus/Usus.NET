using System;
using System.Collections.Generic;

namespace andrena.Usus.net.ExtensionHelper
{
    public class GlobalEventManager
    {
        static GlobalEventManager instance;
        public static GlobalEventManager Instance
        {
            get
            {
                if (instance == null) instance = new GlobalEventManager();
                return instance;
            }
        }

        Dictionary<string, Action<object>> registeredEvents;

        private GlobalEventManager()
        {
            registeredEvents = new Dictionary<string, Action<object>>();
        }

        public void RegisterEvent(string trigger, Action<object> displayAction)
        {
            if (!HasEvent(trigger))
                registeredEvents.Add(trigger, displayAction);
        }

        public void FireEvent(string trigger, object parameter)
        {
            if (HasEvent(trigger))
                registeredEvents[trigger](parameter);
        }

        public bool HasEvent(string trigger)
        {
            return registeredEvents.ContainsKey(trigger);
        }
    }
}
