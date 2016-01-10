using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace UniversityJournal.ViewModel
{
	/// <summary>
	/// Class for Command usage realization
	/// </summary>
	/// <typeparam name="T">Type of parameter to be used in command</typeparam>
	class Command<T>:ICommand
	{
		/// <summary>
		/// Delegate for method to be used in command
		/// </summary>
		private readonly Action<T> _execute;
		private Predicate<T> _canExecute;
		
		public Command(Action<T> execute, Predicate<T> canExecute=null)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("Execute is null");
			}
			this._execute = execute;
			this._canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return this._canExecute == null ? true : this._canExecute((T)parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (this._canExecute != null)
				{
					CommandManager.RequerySuggested += value;
				}
			}
			remove
			{
				if (this._canExecute != null)
				{
					CommandManager.RequerySuggested -= value;
				}
			}
		}
		public void Execute(object parameter)
		{
			if (parameter is T)
			this._execute((T)parameter);
				
		}
		
		//public void RaiseCanExecuteChanged()
		//{
		//	if (CanExecuteChanged != null)
		//		CanExecuteChanged(this, EventArgs.Empty);
		//}
	}
}
