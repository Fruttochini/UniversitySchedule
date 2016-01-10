using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using UniversityJournal.Model;

namespace UniversityJournal.ViewModel
{
	class TeacherVM:BaseViewModel,ITabConfig
	{
		public string TabName {get;set;}

		private List<University_Teacher> _teachers;

		private string _tname;
		private string _tlname;
		private string _temail;
		private DateTime _tbdate;
		private BitmapImage _tphoto;
		private string _tlogin;
		private string _tpwd;

		private Command<object> _addNewTeacher;
		private Command<University_Teacher> _editTeacher;
		private Command<University_Teacher> _deleteTeacher;
		//private Command<University_Teacher> _onSelectionChanged;
		private Command<object> _browseButton;
		private Command<University_Subject> _removeSubject;
		private Command<University_Subject> _addSubject;
		
		private University_Teacher _selectedTeacher;
		private ObservableCollection<University_Subject> _currentSubjects;
		private ObservableCollection<University_Subject> _allSubjects;


		//#Binding Properties
#region Binding Properties

		public string Tname
		{
			get { return _tname; }
			set { _tname = value; RaisePropertyChanged("Tname"); }
		}
		

		public string Tlname
		{
			get { return _tlname; }
			set { _tlname = value; RaisePropertyChanged("Tlname"); }
		}
		

		public string Temail
		{
			get { return _temail; }
			set { _temail = value; RaisePropertyChanged("Temail"); }
		}
		

		public DateTime Tbdate
		{
			get { return _tbdate; }
			set { _tbdate = value; RaisePropertyChanged("Tbdate"); }
		}
		

		public BitmapImage Tphoto
		{
			get { return _tphoto; }
			set { _tphoto = value; RaisePropertyChanged("Tphoto"); }
		}
		public string Tlogin
		{
			get { return _tlogin; }
			set { _tlogin = value; RaisePropertyChanged("Tlogin"); }
		}
		
		public string Tpwd
		{
			get { return _tpwd; }
			set { _tpwd = value; RaisePropertyChanged("Tpwd"); }
		}

		public List<University_Teacher> Teachers
		{
			get { return _teachers; }
			set { _teachers = value; RaisePropertyChanged("Teachers"); }
		}
		public University_Teacher SelectedTeacher
		{
			get { return _selectedTeacher; }
			set { _selectedTeacher = value;
			RaisePropertyChanged("SelectedTeacher");
			ChangeSelectedTeacher();
			}
		}

		public ObservableCollection<University_Subject> CurrentSubjects
		{
			get { return _currentSubjects; }
			set { _currentSubjects = value; RaisePropertyChanged("CurrentSubjects"); }
		}

		public ObservableCollection<University_Subject> AllSubjects
		{
			get { return _allSubjects; }
			set { _allSubjects = value; RaisePropertyChanged("AllSubjects"); }
		}
#endregion
		//### Command Properties
#region Command Properties
		public Command<University_Subject> AddSubject
		{
			get { return _addSubject; }
		}
		public Command<University_Subject> RemoveSubject
		{
			get { return _removeSubject; }
		}
		public Command<object> AddNewTeacher
		{
			get { return _addNewTeacher; }
		}
		public Command<University_Teacher> EditTeacher
		{
			get { return _editTeacher; }
		}
		public Command<University_Teacher> DeleteTeacher
		{
			get { return _deleteTeacher; }
		}
		//public Command<University_Teacher> OnSelectionChanged
		//{
		//	get { return _onSelectionChanged; }
		//}
		public Command<object> BrowseButton
		{
			get { return _browseButton; }
		}
		#endregion

		

//Enable Teacher fields for editing/adding new!
		private bool _ee;
		public bool EditEnabled
		{
			get { return _ee; }
			set
			{
				_ee = value;
				RaisePropertyChanged("EditEnabled");
			}
		}
//################################################


		private string _addButtonName;
		public string AddButtonName
		{
			get { return _addButtonName; }
			set { _addButtonName = value; RaisePropertyChanged("AddButtonName"); }
		}
		private bool _allowAddOperation;

		public bool AllowAddButton
		{
			get { return _allowAddOperation; }
			set { _allowAddOperation = value; RaisePropertyChanged("AllowAddButton"); }
		}
		
		private string _editButtonName;
		public string EditButtonName
		{
			get { return _editButtonName; }
			set { _editButtonName = value; RaisePropertyChanged("EditButtonName"); }
		}

		private bool _blockGrid;
		public bool BlockGrid
		{
			get { return _blockGrid; }
			set { _blockGrid = value; RaisePropertyChanged("BlockGrid"); }
		}

//########################
//## CONSTRUCTOR #########
//########################
		public TeacherVM()
		{
			_addNewTeacher = new Command<object>(AddNewTeacherToDB);
			AddButtonName = "Add New...";
			AllowAddButton = true;
			_editTeacher = new Command <University_Teacher> (EditTeacherFromDB, (s) => SelectedTeacher!=null);
			EditButtonName = "Edit";
			_deleteTeacher = new Command<University_Teacher>(DeleteTeacherFromDB, (s) => s != null);
			_browseButton = new Command<object>(BrowseImage);
			//_onSelectionChanged = new Command<University_Teacher>(ChangeSelectedTeacher);

			///Add PRedicates!!!
			_addSubject = new Command<University_Subject>(AddSubjectFromList,
				s=> SelectedTeacher!=null&&s!=null
				);
			_removeSubject = new Command<University_Subject>(RemoveSubjectFromList,
				s=>SelectedTeacher!=null&&s!=null);
			///^^^^^^
			EditEnabled = false;
			BlockGrid = true;
			RefreshIt();
		}

		private void ChangeSelectedTeacher()
		{
			if (SelectedTeacher != null)
			{
				Tname = SelectedTeacher.First_Name;
				Tlname = SelectedTeacher.Last_Name;
				Tbdate = SelectedTeacher.Birthday;
				Temail = SelectedTeacher.Email;
				if (SelectedTeacher.Photo != null)
					Tphoto = ByteToImage(SelectedTeacher.Photo);
				else
					Tphoto = null;
				Tlogin = SelectedTeacher.Login;
				Tpwd = SelectedTeacher.Password;
				GetCurrentSubjects(SelectedTeacher);
				GetAllSubjects();
			}
		}

		private void AddNewTeacherToDB(object obj)
		{
			SelectedTeacher = null;
			BlockGrid = false;
			Tname = null;
			Tlname = null;
			Tbdate = new DateTime(1985,1,1);
			Temail = null;
			Tphoto = null;
			Tlogin = null;
			Tpwd = null;
			EditEnabled = true;
			AddButtonName = "Save";
			_addNewTeacher = new Command<object>(SaveNewTeacherToDB,
				(t) => !string.IsNullOrWhiteSpace(Tname)
					&& !string.IsNullOrWhiteSpace(Tlname)
					&& Tbdate != null
					&& !string.IsNullOrWhiteSpace(Tlogin)
					&& !string.IsNullOrWhiteSpace(Tpwd));
			RaisePropertyChanged("AddNewTeacher");
		}
		private void SaveNewTeacherToDB(object obj)
		{
			try
			{
				using (_ujc = new UniversityEntities())
				{
					University_Teacher _teach = new University_Teacher();
					_teach.First_Name = Tname;
					_teach.Last_Name = Tlname;
					_teach.Birthday = Tbdate;
					_teach.Email = Temail;
					if (Tphoto != null)
					{
						_teach.Photo = ImageToByte(Tphoto);
					}
					_teach.Login = Tlogin;
					_teach.Password = Tpwd;

					_ujc.University_Teacher.Add(_teach);
					_ujc.SaveChanges();

				}
			}
			catch { }
			finally
			{
				EditEnabled = false;
				AddButtonName = "Add New...";
				_addNewTeacher = new Command<object>(AddNewTeacherToDB);
				RaisePropertyChanged("AddNewTeacher");
				BlockGrid = true;
				RefreshIt();
			}
			
		}
		private void EditTeacherFromDB(University_Teacher obj)
		{
			EditEnabled = true;
			EditButtonName = "Save";
			AllowAddButton = false;
			
			BlockGrid = false;
			_editTeacher = new Command<University_Teacher>(SaveEditedTeacherToDB,
				(t) => !string.IsNullOrWhiteSpace(Tname)
					&& !string.IsNullOrWhiteSpace(Tlname)
					&& Tbdate != null
					&& !string.IsNullOrWhiteSpace(Tlogin)
					&& !string.IsNullOrWhiteSpace(Tpwd));
			RaisePropertyChanged("EditTeacher");

		}

		private void SaveEditedTeacherToDB(University_Teacher obj)
		{
			try
			{
				using (_ujc = new UniversityEntities())
				{
					var _teach = _ujc.University_Teacher.Where(s => s.Teacher_ID == SelectedTeacher.Teacher_ID).Single();
					_teach.First_Name = Tname;
					_teach.Last_Name = Tlname;
					_teach.Birthday = Tbdate;
					_teach.Email = Temail;
					if (Tphoto != null)
					{
						_teach.Photo = ImageToByte(Tphoto);
					}
					_teach.Login = Tlogin;
					_teach.Password = Tpwd;
		
					_ujc.SaveChanges();
				}
			}
			finally
			{
				EditEnabled = false;
				EditButtonName = "Edit";
				_editTeacher = new Command<University_Teacher>(EditTeacherFromDB, (S) => SelectedTeacher != null);
				RaisePropertyChanged("EditTeacher");
				AllowAddButton = true;
				BlockGrid = true;
				RefreshIt();
			}
		}

		private void DeleteTeacherFromDB(University_Teacher obj)
		{
			try
			{
				using (_ujc = new UniversityEntities())
				{
					var _teach = _ujc.University_Teacher.Where(s => s.Teacher_ID == obj.Teacher_ID).FirstOrDefault();
					_ujc.University_Teacher.Remove(_teach);
					_ujc.SaveChanges();
				}
			}
			finally
			{
				RefreshIt();
			}
			
		}
		private void BrowseImage(object parameter)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "JPG images (*.jpg)|*.jpg";
			ofd.Multiselect = false;
			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;
			if (ofd.ShowDialog() == true)
			{
				try
				{
					BitmapImage bmp = new BitmapImage(new Uri(ofd.FileName.Trim()));
					Tphoto = bmp;
				}
				catch
				{ }
			}
		}
		private void RemoveSubjectFromList(University_Subject obj)
		{
			using (_ujc = new UniversityEntities())
			{
				var currsubj = _ujc.University_Subject.Where(s => s.Subject_ID == obj.Subject_ID).FirstOrDefault();
				var currteach = _ujc.University_Teacher.Where(t => t.Teacher_ID == SelectedTeacher.Teacher_ID).FirstOrDefault();
				currteach.University_Subject.Remove(currsubj);
				_ujc.SaveChanges();
				GetCurrentSubjects(SelectedTeacher);
				GetAllSubjects();
			}
		}
		private void AddSubjectFromList(University_Subject obj)
		{
			using (_ujc = new UniversityEntities())
			{
				var currsubj = _ujc.University_Subject.Where(s => s.Subject_ID == obj.Subject_ID).FirstOrDefault();
				var currteach = _ujc.University_Teacher.Where(t => t.Teacher_ID == SelectedTeacher.Teacher_ID).FirstOrDefault();
				currteach.University_Subject.Add(currsubj);
				_ujc.SaveChanges();
				GetCurrentSubjects(SelectedTeacher);
				GetAllSubjects();
			}
		}

		void UpdateTeachersList()
		{
			using (_ujc = new UniversityEntities())
			{
				_teachers = (from teac in _ujc.University_Teacher
							 select teac).ToList();
				RaisePropertyChanged("Teachers");
			}
		}

		void GetCurrentSubjects(University_Teacher obj)
		{
			if (obj != null)
			{
				using (_ujc = new UniversityEntities())
				{
					var _teach = _ujc.University_Teacher.Where(s => s.Teacher_ID == obj.Teacher_ID).FirstOrDefault();
					CurrentSubjects = new ObservableCollection<University_Subject>(_teach.University_Subject.ToList());
				}
			}
		}

		void GetAllSubjects()
		{
			using(_ujc= new UniversityEntities())
			{
				if (CurrentSubjects!=null&&SelectedTeacher!=null)
				{
					var tmpData = _ujc.University_Subject.ToList();
					var teach = _ujc.University_Teacher.Where(e=>e.Teacher_ID==SelectedTeacher.Teacher_ID).FirstOrDefault();
					var exclData = teach.University_Subject.ToList();
					var res = tmpData.Except(exclData).ToList();
					AllSubjects = new ObservableCollection<University_Subject>(res);
				}
			}
		}

		
		void RefreshIt()
		{
			SelectedTeacher = null;
			UpdateTeachersList();
			GetCurrentSubjects(null);
			GetAllSubjects();
		}

		public System.Windows.Visibility Vis
		{
			get;
			set;
		}


		public void Refresh()
		{
			RefreshIt();
		}
	}
}
