using System.Windows.Controls;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.Dialogs;
using andrena.Usus.net.View.Dialogs.ViewModels;

namespace andrena.Usus.net.View
{
    public partial class Cockpit : UserControl
    {
        public ViewModels.Cockpit.Cockpit ViewModel { get { return DataContext as ViewModels.Cockpit.Cockpit; } }

        public Cockpit()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var listDisplay = new ListDisplay();
            listDisplay.ItemClicked += i => ViewModel.JumpToMethod(i as MethodMetricsReport);
            listDisplay.DataContext = CreateChangedMethods();
            listDisplay.Show();
        }

        private ListDisplay<MethodMetricsReport> CreateChangedMethods()
        {
            var methodChanges = new ListDisplay<MethodMetricsReport>("Changed Methods since last build");
            methodChanges.AddAll(ViewModel.ChangedMethods);
            return methodChanges;
        }
    }
}
