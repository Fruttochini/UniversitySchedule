using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UniversityJournal.ViewModel
{
	//add StudentFilter
	
	class MainWindowVM:BaseViewModel
	{
        public MainWindowVM(bool admin, int teachid)
        {
            _isAdmin = admin;
            TeachID = teachid;
            if (admin)
            {
                LoggedIn = "Admin";
                forA = Visibility.Visible;
                forT = Visibility.Collapsed;
            }
            else
            {
                forT = Visibility.Visible;
                forA = Visibility.Collapsed;
                using (_ujc = new Model.UniversityEntities())
                {
                    var _tmpteach = _ujc.University_Teacher.Where(t => t.Teacher_ID == TeachID).FirstOrDefault();
                    LoggedIn = _tmpteach.First_Name + " " + _tmpteach.Last_Name;
                }
            }
            _schdVM = new ScheduleVM() { TabName = "Schedule", Vis = forA };
            _gvm = new GroupVM() { TabName = "Groups", Vis = forA };
            _teacVM = new TeacherVM() { TabName = "Teachers", Vis = forA };
            _subjvm = new SubjectVM() { TabName = "Subjects", Vis = forA };
            _studvm = new StudentVM() { TabName = "Students", Vis = forA };
            _teachIntVM = new TeacherInterfaceVM(TeachID) { TabName = "", TeacherID = TeachID, Vis = forT };
            if (!_isAdmin)
                SelectIndex = 5;
        }

        private string _loggedIn;

		public string LoggedIn
		{
			get { return _loggedIn; }
			set { _loggedIn = value; RaisePropertyChanged("LoggedIn"); }
		}

		private bool _isAdmin;
		private int TeachID;
		private int _selectedIndex;
		public int SelectIndex { get { return _selectedIndex; }
			set { _selectedIndex = value; RaisePropertyChanged("SelectedIndex"); Refresh(); }
		}
		Visibility forA;
		Visibility forT;

		ScheduleVM _schdVM ;
		GroupVM _gvm ;
		SubjectVM _subjvm;
		StudentVM _studvm;
		TeacherVM _teacVM;
		TeacherInterfaceVM _teachIntVM;

		public TeacherInterfaceVM TeachIntVM
		{
			get { return _teachIntVM; }
		}

		public ScheduleVM schdVM
		{
			get { return _schdVM; }
		}
		public TeacherVM TeacVM
		{
			get { return _teacVM; }
		}

		public StudentVM Studvm
		{
			get { return _studvm; }
		}
		public GroupVM gvm
		{
			get { return _gvm; }
		}

		public SubjectVM subjvm
		{
			get { return _subjvm; }
		}

		

		private void Refresh()
		{
			if (_isAdmin)
			{
				_schdVM.Refresh();
				_schdVM.SelectedFilter = _schdVM.FilterList[0];
				_gvm.Refresh();
				_teacVM.Refresh();
				_subjvm.Refresh();
				_studvm.Refresh();
			}
				_teachIntVM.Refresh();
		}
	}
}
