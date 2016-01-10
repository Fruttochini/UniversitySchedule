using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UniversityJournal.View
{
	/// <summary>
	/// Interaction logic for LoginScreen.xaml
	/// </summary>
	public partial class LoginScreen : Window
	{
		private Dictionary<string, string> LogPas = new Dictionary<string, string>();
		public int Teacher { get; set; }
		public bool IsAdmin { get; set; }
		public LoginScreen()
		{
			InitializeComponent();
			LogPas.Add("admin", "admin");
			using (var _ujc = new Model.UniversityEntities())
			{
				var _teachers = _ujc.University_Teacher.Select(s => s);
				foreach (var tch in _teachers)
				{
					LogPas.Add(tch.Login, tch.Password);
				}
			}

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			KeyValuePair<string,string> lgnpwd = new KeyValuePair<string,string>(this.login.Text,this.pwd.Password);
			if (!LogPas.Contains(lgnpwd))
			{
				this.InfoBlock.Text = "Incorrect Login!";
				return;
			}
			else
			{
				if (lgnpwd.Key == "admin")
				{
					IsAdmin = true;
					Teacher = 0;
					DialogResult = true;
				}
				else
				{
					using (var _ujc = new Model.UniversityEntities())
					{
						Teacher = _ujc.University_Teacher.Where(t => t.Login == lgnpwd.Key).FirstOrDefault().Teacher_ID;
					}
					IsAdmin = false;
					this.DialogResult = true;
				}
				
			}
		}
	}
}
