using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using UniversityJournal.Model;
using UniversityJournal.View;

namespace UniversityJournal.ViewModel
{
	class StudentVM:BaseViewModel,ITabConfig
	{
        public StudentVM()
        {
            _addNewStudent = new Command<object>(AddNewStudentToDB);
            _editStudent = new Command<University_Student>(EditStudentFromDB, (s) => s != null);
            _deleteStudent = new Command<University_Student>(DeleteStudentFromDB, (s) => s != null);
            _browseButton = new Command<object>(BrowseImage);
            UpdateStudentsList();
        }
        
        private List<University_Student> _students;

		private Command<object> _addNewStudent;
		private Command<University_Student> _editStudent;
		private Command<University_Student> _deleteStudent;
		private University_Student _selectedStudent;
		private string _searchString;

		public string SearchString
		{
			get { return _searchString; }
			set { _searchString = value; RaisePropertyChanged("SearchString"); UpdateStudentsList(); }
		}

		public University_Student SelectedStudent
		{
			get { return _selectedStudent; }
			set { _selectedStudent = value; RaisePropertyChanged("SelectedStudent"); }
		}

		public Command<object> AddNewStudent
		{
			get { return _addNewStudent; }
		}
		public Command<University_Student> EditStudent
		{
			get { return _editStudent; }
		}
		public Command<University_Student> DeleteStudent
		{
			get { return _deleteStudent; }
		}

		public List<University_Student> Students
		{
			get { return _students; }
			set { _students = value; RaisePropertyChanged("Students"); }
		}
		public string TabName { get; set; }

		

		private void AddNewStudentToDB(object obj)
		{
			var childWindow = new EditStudentWindow() { DataContext = this, Title="Add new Student"};
			CloseCommand = new Action(() => childWindow.Close());
			StudentName = null;
			StudentLastName = null;
			StudentEmail = null;
			StudentBirthdate = new DateTime(2000, 01, 01);
			StudentPhoto = null;
			//StudentPhoto = new BitmapImage(new Uri("bin/Debug/no_img.jpg", UriKind.Relative));
			ButtonName = "Add";
			SaveButton = new Command<object>(AddStudent, 
				(s)=>!string.IsNullOrWhiteSpace(StudentName) 
					&& !string.IsNullOrWhiteSpace(StudentLastName) && StudentBirthdate!=null);
			childWindow.ShowDialog();
		}
		private void EditStudentFromDB(University_Student obj)
		{
			var childWindow = new EditStudentWindow() { DataContext = this, Title="Edit Student" };
			CloseCommand = new Action(() => childWindow.Close());
			StudentName = obj.First_Name;
			StudentLastName = obj.Last_Name;
			StudentEmail = obj.Email;
			StudentBirthdate = obj.Birthday;
			if (obj.Photo == null)
				StudentPhoto = null;
			else
				StudentPhoto = ByteToImage(obj.Photo);
			ButtonName = "Edit";
			SaveButton = new Command<object>(UpdateStudent,
				(s)=>!string.IsNullOrWhiteSpace(StudentName) 
					&& !string.IsNullOrWhiteSpace(StudentLastName)&& StudentBirthdate!=null);
			childWindow.ShowDialog();
		}
		private void DeleteStudentFromDB(University_Student obj)
		{
			_ujc = new UniversityEntities();

			var removestud = _ujc.University_Student.Single((s) => s.Student_ID == SelectedStudent.Student_ID);
			_ujc.University_Student.Remove(removestud);
			_ujc.SaveChanges();
			UpdateStudentsList();	
		}

		void UpdateStudentsList()
		{
			using (_ujc = new UniversityEntities())
			{
				if (!string.IsNullOrEmpty(SearchString))
				{
					_students = new List<University_Student>();
					Regex _sp = new Regex(SearchString+"{1}",RegexOptions.IgnoreCase);
					var _tmp = _ujc.University_Student.Select(s => s);
					foreach (var it in _tmp)
					{
						if (_sp.IsMatch(it.Last_Name)||_sp.IsMatch(it.First_Name))
						{
							_students.Add(it);
						}
					}
				}
				else
				{
					//_students = new List<University_Student>();
					_students = _ujc.University_Student
						//	.Where(s => s.Last_Name.Contains(SearchString))
					.Select(s => s)
					.ToList();
				}
				//_students.AddRange(
				//	_ujc.University_Student
				//	.Where(s => s.First_Name.Contains(SearchString))
				//	.ToList()
				//	);
					//(from stud in _ujc.University_Student

					//		 select stud).ToList();
				RaisePropertyChanged("Students");
			}
		}

		#region ChildWindow
		private string _studentName;
		private string _studentLastName;
		private string _studentEmail;
		private DateTime _studentBirthdate;
		private BitmapImage _studentPhoto;

		private Command<object> _saveButton;
		private Command<object> _browseButton;

		public Command<object> BrowseButton
		{
			get { return _browseButton; }
		}

		public Command<object> SaveButton
		{
			get { return _saveButton; }
			set { 
				_saveButton = value; RaisePropertyChanged("SaveButton");
			}
		}

		public Action CloseCommand { get; set; }

		public string StudentName
		{
			get { return _studentName; }
			set { _studentName = value; RaisePropertyChanged("StudentName"); }
		}
		public string StudentLastName
		{
			get { return _studentLastName; }
			set { _studentLastName = value; RaisePropertyChanged("StudentLastName"); }
		}
		public string StudentEmail
		{
			get { return _studentEmail; }
			set { _studentEmail = value; RaisePropertyChanged("StudentEmail"); }
		}
		public DateTime StudentBirthdate
		{
			get { return _studentBirthdate; }
			set { _studentBirthdate = value; RaisePropertyChanged("StudentBirthdate"); }
		}

		public BitmapImage StudentPhoto
		{
			get { return _studentPhoto; }
			set 
			{
				_studentPhoto = value;
				RaisePropertyChanged("StudentPhoto");
			}
		}

		public string ButtonName { get; set; }
		#endregion

		private void BrowseImage(object parameter)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "JPG images (*.jpg)|*.jpg";
			ofd.Multiselect = false;
			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;
			if (ofd.ShowDialog()==true)
			{
				try
				{
					BitmapImage bmp = new BitmapImage(new Uri(ofd.FileName.Trim()));
					StudentPhoto = bmp;
				}
				catch
				{ }
			}
		}

		private void UpdateStudent(object parameter)
		{
			using (_ujc = new UniversityEntities())
			{
				//try
				{
					University_Student tmp = _ujc.University_Student.Single((st) => st.Student_ID == SelectedStudent.Student_ID);
					tmp.First_Name = StudentName;
					tmp.Last_Name = StudentLastName;
					tmp.Birthday = StudentBirthdate;
					tmp.Email = StudentEmail;
					if (StudentPhoto!=null)
					{
						tmp.Photo = ImageToByte(StudentPhoto);
					}
					else tmp.Photo = ImageToByte(new BitmapImage(new Uri(@"G:\Универ\GoogleDrive_oldan\Bionic Final Project\UniversityJournal\UniversityJournal\bin\Debug\no_img.jpg")));
					_ujc.SaveChanges();
					UpdateStudentsList();
					CloseCommand();
					
				}
				//catch
				{
				}
			}
		}

		private void AddStudent(object parameter)
		{
			using (_ujc = new UniversityEntities())
			{
				try
				{
					University_Student tmp = new University_Student();
					tmp.First_Name = StudentName;
					tmp.Last_Name = StudentLastName;
					tmp.Birthday = StudentBirthdate;
					tmp.Email = StudentEmail;
					if (StudentPhoto == null)
						tmp.Photo = null;
					else
						tmp.Photo = ImageToByte(StudentPhoto);
					_ujc.University_Student.Add(tmp);
					_ujc.SaveChanges();
					UpdateStudentsList();
					CloseCommand();
				}
				catch { }
			}
		}

		public System.Windows.Visibility Vis
		{
			get;
			set;
		}

		public void Refresh()
		{
			UpdateStudentsList();
		}
	}
}
