using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UniversityJournal.ViewModel
{
	interface ITabConfig
	{
		string TabName { get; set; }
		Visibility Vis { get; set; }

		void Refresh();
	}
}
