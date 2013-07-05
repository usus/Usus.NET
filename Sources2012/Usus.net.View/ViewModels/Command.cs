using System;
using System.Windows.Input;

namespace andrena.Usus.net.View.ViewModels
{
	public class Command : ICommand
	{
		private readonly Action _Action;
		
		public Command(Action action)
		{
			_Action = action;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public event System.EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			_Action();
		}
	}
}
