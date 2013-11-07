using System.Windows.Controls;

namespace andrena.Usus.net.View.ViewModels.TypeCycles
{
	/// <summary>
	/// Interaction logic for NamespaceCycleList.xaml
	/// </summary>
	public partial class TypeCycleListView : UserControl
	{
		public TypeCycleListView()
		{
			InitializeComponent();
		}

		private void SelectType(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var vm = DataContext as TypeCycles;
			vm.Jump();

		}
	}
}
