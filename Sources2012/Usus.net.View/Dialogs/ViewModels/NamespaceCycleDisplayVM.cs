using System.Collections.ObjectModel;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
    public class NamespaceCycleDisplayVM
    {
        public string Header { get; private set; }
        public ObservableCollection<string> MainEntries { get; private set; }
        public ObservableCollection<string> SubEntries { get; private set; }
        private NamespaceCycle cycle;

        public NamespaceCycleDisplayVM(string header)
        {
            Header = header;
            MainEntries = new ObservableCollection<string>();
            SubEntries = new ObservableCollection<string>();
        }

        public void Display(NamespaceCycle namespaceCycle)
        {
            cycle = namespaceCycle;
            foreach (var namespaceInCycle in cycle.Namespaces) MainEntries.Add(namespaceInCycle);
        }

        public void SelectNamespace(string namespaceName)
        {
            SubEntries.Clear();
            foreach (var type in cycle.TypesReferencingOutOf(namespaceName)) SubEntries.Add(type);
        }

        public void SelectType(string type)
        {
            cycle.JumpTo(type);
        }
    }
}