using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace UniversityJournal.ViewModel
{
	class LoginScreenVM:BaseViewModel
	{
		
		private ICommand _login;
		private ICommand _exit;
		private string _lgn;
		private PasswordBox _pwd;
		private Dictionary<string, string> LogPas = new Dictionary<string, string>();
		public Action CloseCommand { get; set; }

		public string Lgn
		{
			get { return _lgn; }
			set 
			{ 
				_lgn = value;
				RaisePropertyChanged("Lgn");
			}
		}
		public PasswordBox Pwd
		{
			get { return _pwd; }
			set 
			{
				_pwd = value;
				RaisePropertyChanged("Pwd");
			}
		}

		public ICommand Exit
		{
			get { return _exit; }
		}

		public ICommand Login
		{
			get { return _login; }
		}

		public LoginScreenVM()
		{
			_login = new Command<object>(DoLogin);
			LogPas.Add("admin", "admin");
		}

		private void LoadSecurityData()
		{
			using(_ujc = new Model.UniversityEntities())
			{
				var _teachers = _ujc.University_Teacher.Select(s => s);
				foreach (var tch in _teachers)
				{
					LogPas.Add(tch.Login, tch.Password);
				}
			}
		}
		private void DoLogin(object obj)
		{
			if (!LogPas.Contains(new KeyValuePair<string,string>(_lgn,(obj as PasswordBox).Password)))
			{
				return;
			}
		}

	}
}
