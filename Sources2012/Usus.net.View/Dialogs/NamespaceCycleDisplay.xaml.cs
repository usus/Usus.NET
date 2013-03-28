using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using andrena.Usus.net.View.Dialogs.ViewModels;

namespace andrena.Usus.net.View.Dialogs
{
    public partial class NamespaceCycleDisplay : Window
    {
        public NamespaceCycleDisplay()
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
