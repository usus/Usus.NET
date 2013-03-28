using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace andrena.Usus.net.View.Dialogs
{
    public partial class ListDisplay : Window
    {
        public event Action<object> ItemClicked;

        public ListDisplay()
        {
            InitializeComponent();
            ItemClicked += i => { };
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListBox).SelectedItem;
            if (selectedItem != null) TakeValue(selectedItem);
        }

        private void TakeValue(object selectedItem)
        {
            ItemClicked(selectedItem);
            this.Close();
        }
    }
}
