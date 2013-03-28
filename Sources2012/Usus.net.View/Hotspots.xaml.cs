using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace andrena.Usus.net.View
{
    public partial class Hotspots : UserControl
    {
        public ViewModels.Hotspots.Hotspots ViewModel { get { return DataContext as ViewModels.Hotspots.Hotspots; } }

        public Hotspots()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selections = sender as MultiSelector;
            ViewModel.DoubleClick(selections.SelectedItem);
        }
    }
}
