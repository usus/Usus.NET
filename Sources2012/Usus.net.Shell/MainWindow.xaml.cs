using System.Windows;

namespace andrena.Usus.net.Shell
{
    public partial class MainWindow : Window
    {
        ShellViewModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ShellViewModel();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Cockpit.DataContext = CreateCockpitViewModel();
            Hotspots.DataContext = CreateHotspotsViewModel();
            Distributions.DataContext = CreateDistribtionsViewModel();
            SQI.DataContext = CreateSQIViewModel();
        }

        private View.ViewModels.Cockpit.Cockpit CreateCockpitViewModel()
        {
            var cockpit = new View.ViewModels.Cockpit.Cockpit { Dispatchable = Cockpit };
            cockpit.RegisterHub(ViewModel.Hub);
            return cockpit;
        }

        private View.ViewModels.Hotspots.Hotspots CreateHotspotsViewModel()
        {
            var hotspots = new View.ViewModels.Hotspots.Hotspots { Dispatchable = Hotspots };
            hotspots.RegisterHub(ViewModel.Hub);
            return hotspots;
        }

        private View.ViewModels.Distributions.Distributions CreateDistribtionsViewModel()
        {
            var distributions = new View.ViewModels.Distributions.Distributions { Dispatchable = Distributions };
            distributions.RegisterHub(ViewModel.Hub);
            return distributions;
        }

        private View.ViewModels.SQI.SQI CreateSQIViewModel()
        {
            var sqi = new View.ViewModels.SQI.SQI { Dispatchable = SQI };
            sqi.Details = new SqiDeatils();
            sqi.RegisterHub(ViewModel.Hub);
            return sqi;
        }

        private void StartAnalysis(object sender, RoutedEventArgs e)
        {
            ViewModel.AnalyzeClicked(this);
        }
    }
}
