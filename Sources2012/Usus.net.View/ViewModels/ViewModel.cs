using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Threading;

namespace andrena.Usus.net.View.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public DispatcherObject Dispatchable { private get; set; }

        public void Dispatch(Action toDispatch)
        {
            Dispatchable.Dispatcher.BeginInvoke(toDispatch); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Changed<R>(Expression<Func<R>> property)
        {
            Changed(GetNameForLocator(property));
        }

        public void Changed(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private string GetNameForLocator(LambdaExpression locator)
        {
            return ((MemberExpression)locator.Body).Member.Name;
        }
    }
}
