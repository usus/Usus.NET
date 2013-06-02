using andrena.Usus.net.View.Dialogs.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace andrena.Usus.net.View.Dialogs
{
	/// <summary>
	/// Interaction logic for NamespaceCycleList.xaml
	/// </summary>
	public partial class NamespaceCycleListView : UserControl
	{
		public NamespaceCycleListView()
		{
			InitializeComponent();
		}

		private void SelectNamespace(object sender, MouseButtonEventArgs e)
		{
			SelectionOf(sender, (vm, selected) => vm.SelectNamespace(selected));
		}

		private void SelectType(object sender, MouseButtonEventArgs e)
		{
			SelectionOf(sender, (vm, selected) => vm.SelectType(selected));
		}

		private void SelectionOf(object sender, Action<NamespaceCycleDisplayVM, string> select)
		{
			var selectedItem = (sender as ListBox).SelectedItem;
			if (selectedItem != null)
			{
				var vm = DataContext as NamespaceCycleDisplayVM;
				select(vm, selectedItem as string);
			}
		}
	}
}
