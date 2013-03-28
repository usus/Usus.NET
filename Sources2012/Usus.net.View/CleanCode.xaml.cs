using System.Windows.Controls;
using System.Diagnostics;

namespace andrena.Usus.net.View
{
    public partial class CleanCode : UserControl
    {
        public CleanCode()
        {
            InitializeComponent();
            DataContext = new ViewModels.CleanCode.CleanCodeRanks();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }
    }
}
