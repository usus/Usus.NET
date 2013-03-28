using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
    public class ListDisplay<T>
    {
        public string Header { get; private set; }
        public ObservableCollection<T> Entries { get; private set; }
        
        public ListDisplay(string header)
        {
            Header = header;
            Entries = new ObservableCollection<T>();
        }

        public void AddAll(IEnumerable<T> entries)
        {
            if (entries != null)
                foreach (var entry in entries) Entries.Add(entry);
        }
    }
}
