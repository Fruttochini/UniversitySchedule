using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UniversityJournal.View;
using UniversityJournal.ViewModel;

namespace UniversityJournal
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private bool isAdmin;
		private int TeachID;
		public App()
		{
			LoginScreen lgscr = new LoginScreen();
			bool? logout = true;
			while (logout == true)
			{
				MainWindow lw = new MainWindow() {Title="University Logbook"};
				if (RunLogin(lgscr) == true)
				{
					var tmp = new MainWindowVM(isAdmin, TeachID);
					lw.DataContext = tmp;
					logout = lw.ShowDialog();
				}
				else
				{ 
					logout = false;
				}
			}
			this.Shutdown();
		}

		private bool?  RunLogin (LoginScreen log)
		{
			log = new LoginScreen() { Title = "Login to University Logbook" };
			var _dialogres = log.ShowDialog();
			if (_dialogres == true)
			{
				isAdmin = log.IsAdmin;
				TeachID = log.Teacher;
				return true;
			}
			return false;
		}
	}
}
