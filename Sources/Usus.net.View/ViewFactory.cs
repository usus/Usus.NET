﻿using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;
using System.Windows;

namespace andrena.Usus.net.View
{
	public static class ViewFactory
	{
		public static FrameworkElement CreateCockpit(ViewHub hub, IJumpToSource jumpToSource)
		{
			var cockpitView = new View.Cockpit();
			var cockpitViewModel = new ViewModels.Cockpit.Cockpit { Dispatchable = cockpitView };
			cockpitViewModel.RegisterHub(hub);
			cockpitViewModel.SourceLocating = jumpToSource;
			cockpitView.DataContext = cockpitViewModel;
			return cockpitView;
		}

		public static FrameworkElement CreateDistributions(ViewHub hub)
		{
			var distributionsView = new View.Distributions();
			var distributionsViewModel = new ViewModels.Distributions.Distributions { Dispatchable = distributionsView };
			distributionsViewModel.RegisterHub(hub);
			distributionsView.DataContext = distributionsViewModel;
			return distributionsView;
		}

		public static FrameworkElement CreateCurrent(ViewHub hub)
		{
			var currentView = new View.Current();
			var currentViewModel = new ViewModels.Current.Current { Dispatchable = currentView };
			currentViewModel.RegisterHub(hub);
			currentView.DataContext = currentViewModel;
			return currentView;
		}

		public static FrameworkElement CreateHotspots(ViewHub hub, IJumpToSource jumpToSource)
		{
			var hotspotsView = new View.Hotspots();
			var hotspotsViewModel = new ViewModels.Hotspots.Hotspots { Dispatchable = hotspotsView };
			hotspotsViewModel.RegisterHub(hub);
			hotspotsViewModel.SourceLocating = jumpToSource;
			hotspotsView.DataContext = hotspotsViewModel;
			return hotspotsView;
		}

		public static FrameworkElement CreateSQI(ViewHub hub, IKnowSqiDetails sqiDetails)
		{
			var sqiView = new View.SQI();
			var sqiViewModel = new ViewModels.SQI.SQI { Dispatchable = sqiView };
			sqiViewModel.Details = sqiDetails;
			sqiViewModel.RegisterHub(hub);
			sqiView.DataContext = sqiViewModel;
			return sqiView;
		}

		public static FrameworkElement CreateGraphs(ViewHub hub)
		{
			var graphsView = new View.Graphs();
			var graphsViewModel = new ViewModels.Graphs.Graphs { Dispatchable = graphsView };
			graphsViewModel.RegisterHub(hub);
			graphsView.DataContext = graphsViewModel;
			return graphsView;
		}

		public static FrameworkElement CreateTypeCycles(ViewHub hub)
		{
			var typeCyclesView = new View.TypeCycles();
			var typeCyclesViewModel = new ViewModels.TypeCycles.TypeCycles { Dispatchable = typeCyclesView };
			typeCyclesViewModel.RegisterHub(hub);
			typeCyclesView.DataContext = typeCyclesViewModel;
			return typeCyclesView;
		}
	}
}
