using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityJournal.Model;

namespace UniversityJournal.ViewModel
{
	class GroupVM:BaseViewModel,ITabConfig
	{
		private ObservableCollection<University_Group> _groups;
		private University_Group _selectedGroup;
		private string _groupNameEdit;
		private ObservableCollection<University_Subject> _currentSubjects;
		private ObservableCollection<University_Subject> _allSubjects;
		private ObservableCollection<University_Student> _students;
		private ObservableCollection<University_Student> _allAvailableStudents;


		private Command<University_Group> _deleteGroup;
		private Command<University_Group> _editGroup;
		private Command<string> _addNewGroup;
		private Command<University_Subject> _addSubject;
		private Command<University_Subject> _removeSubject;
		private Command<University_Student> _addStudents;
		private Command<University_Student> _removeStudents;

		public Command<University_Student> RemoveStudents
		{
			get { return _removeStudents; }
		}

		public Command<University_Student> AddStudents
		{
			get { return _addStudents; }
		}

		public ObservableCollection<University_Group> Groups
		{
			get { return _groups; }
			set { _groups = value; RaisePropertyChanged("Groups"); }
		}
		public University_Group SelectedGroup
		{
			get { return _selectedGroup; }
			set { _selectedGroup = value; 
				RaisePropertyChanged("SelectedGroup");
				if (value!=null)
				{
					_groupNameEdit = value.Group_Name;
					RaisePropertyChanged("GroupNameEdit");
				}
				GetCurrentSubjects(value);
				GetAllSubjects();
				GetCurrentStudents(value);
				GetAllStudents();
			}
		}

		
		public string GroupNameEdit
		{
			get { return _groupNameEdit; }
			set { _groupNameEdit = value; RaisePropertyChanged("GroupNameEdit"); }
		}
		public ObservableCollection<University_Subject> AllSubjects
		{
			get { return _allSubjects; }
			set { _allSubjects = value; RaisePropertyChanged("AllSubjects"); }
		}
		public ObservableCollection<University_Subject> CurrentSubjects
		{
			get { return _currentSubjects; }
			set { _currentSubjects = value; RaisePropertyChanged("CurrentSubjects");}
		}
		public ObservableCollection<University_Student> Students
		{
			get { return _students; }
			set { _students = value; RaisePropertyChanged("Students"); }
		}
		public ObservableCollection<University_Student> AllAvailableStudents
		{
			get { return _allAvailableStudents; }
			set { _allAvailableStudents = value; RaisePropertyChanged("AllAvailableStudents"); }
		}
		
//Command Properties
#region Command Properties
		public Command<University_Group> DeleteGroup
		{
			get { return _deleteGroup; }
		}
		public Command<University_Group> EditGroup
		{
			get { return _editGroup; }
		}
		public Command<string> AddNewGroup
		{
			get { return _addNewGroup; }
		}
		public Command<University_Subject> AddSubject
		{
			get { return _addSubject; }
		}
		public Command<University_Subject> RemoveSubject
		{
			get { return _removeSubject; }
		}
#endregion

		public string TabName { get; set; }		
//CONSTRUCTOR
		public GroupVM()
		{
			_deleteGroup = new Command<University_Group>(DeleteGroupFromDB, s => s != null);
			_editGroup = new Command<University_Group>(EditGroupFromDB, s => s != null
				&& !string.IsNullOrWhiteSpace(GroupNameEdit));
			_addNewGroup = new Command<string>(AddNewGroupToDB,
				s =>
				{	
					if (!string.IsNullOrWhiteSpace(s))
						using(_ujc=new UniversityEntities())
						{
							var cnt=_ujc.University_Group.Where(gr => gr.Group_Name == s).ToList().Count;
							return !(cnt > 0);
						}
					return false;
				});
			_addSubject = new Command<University_Subject>(AddSubjectFromList,
				s => SelectedGroup != null && s != null
				);
			_removeSubject = new Command<University_Subject>(RemoveSubjectFromList,
				s => SelectedGroup != null && s != null);

			_addStudents = new Command<University_Student>(AddStudentToGroup, s => SelectedGroup != null && s != null);
			_removeStudents = new Command<University_Student>(RemoveStudentFromGroup, s => SelectedGroup != null && s != null);

			RefreshIt();
		}

		
//Command Methods
		private void DeleteGroupFromDB(University_Group obj)
		{
			try
			{
				using (_ujc = new UniversityEntities())
					{
						var _group = _ujc.University_Group.Where(s => s.Group_ID == obj.Group_ID).FirstOrDefault();
						_ujc.University_Group.Remove(_group);
						_ujc.SaveChanges();
					}
			}
		
			finally
			{
				RefreshIt();
			}
		}
		private void EditGroupFromDB(University_Group obj)
		{
			try
			{
				using (_ujc = new UniversityEntities())
				{
					var _group = _ujc.University_Group.Where(s => s.Group_ID == obj.Group_ID).FirstOrDefault();
					_group.Group_Name = GroupNameEdit;
					_ujc.SaveChanges();
			
				}
			}
			catch { }
			finally
			{
				RefreshIt();
			}
		}
		private void AddNewGroupToDB(string obj)
		{
			try
			{
				using (_ujc = new UniversityEntities())
				{
					University_Group _group = new University_Group();
					_group.Group_Name = obj;
					_ujc.University_Group.Add(_group);
					_ujc.SaveChanges();
				}
			}
			catch { }
			finally
			{
				RefreshIt();
			}
		
		}

		private void RemoveSubjectFromList(University_Subject obj)
		{
			using (_ujc = new UniversityEntities())
			{
				var currsubj = _ujc.University_Subject.Where(s => s.Subject_ID == obj.Subject_ID).FirstOrDefault();
				var currgroup = _ujc.University_Group.Where(t => t.Group_ID == SelectedGroup.Group_ID).FirstOrDefault();
				currgroup.University_Subject.Remove(currsubj);
				_ujc.SaveChanges();
				GetCurrentSubjects(SelectedGroup);
				GetAllSubjects();
			}
		}
		private void AddSubjectFromList(University_Subject obj)
		{
			using (_ujc = new UniversityEntities())
			{
				var currsubj = _ujc.University_Subject.Where(s => s.Subject_ID == obj.Subject_ID).FirstOrDefault();
				var currgroup = _ujc.University_Group.Where(t => t.Group_ID == SelectedGroup.Group_ID).FirstOrDefault();
				currgroup.University_Subject.Add(currsubj);
				_ujc.SaveChanges();
				GetCurrentSubjects(SelectedGroup);
				GetAllSubjects();
			}
		}
		private void AddStudentToGroup (University_Student parameter)
		{
			
			using (_ujc = new UniversityEntities())
			{
				var _selstud = _ujc.University_Student.Where(s=>s.Student_ID == parameter.Student_ID).FirstOrDefault();
				var _group = _ujc.University_Group.Where(gr => gr.Group_ID == SelectedGroup.Group_ID).FirstOrDefault();
				_group.University_Student.Add(_selstud);
				_ujc.SaveChanges();
			}
			GetAllStudents();
			GetCurrentStudents(SelectedGroup);

		}
		private void RemoveStudentFromGroup(University_Student obj)
		{
			using (_ujc = new UniversityEntities())
			{
				var currstud = _ujc.University_Student.Where(s => s.Student_ID == obj.Student_ID).FirstOrDefault();
				var currgroup = _ujc.University_Group.Where(t => t.Group_ID == SelectedGroup.Group_ID).FirstOrDefault();
				currgroup.University_Student.Remove(currstud);
				_ujc.SaveChanges();
				GetAllStudents();
				GetCurrentStudents(SelectedGroup);
			}
		}
		private void RefreshIt()
		{
			UpdateGroupList();
			GetCurrentStudents(null);
			GetAllSubjects();
			GetCurrentStudents(null);
		}
		private void UpdateGroupList()
		{
			using (_ujc = new UniversityEntities())
			{
				var tmp = (from gr in _ujc.University_Group
						   select gr).ToList();
				_groups = new ObservableCollection<University_Group>(tmp);
				RaisePropertyChanged("Groups");
			}
		}
		void GetCurrentSubjects(University_Group obj)
		{
			if (obj != null)
			{
				using (_ujc = new UniversityEntities())
				{
					var _teach = _ujc.University_Group.Where(s => s.Group_ID == obj.Group_ID).FirstOrDefault();
					CurrentSubjects = new ObservableCollection<University_Subject>(_teach.University_Subject.ToList());
				}
			}
		}
		void GetAllSubjects()
		{
			using (_ujc = new UniversityEntities())
			{
				if (CurrentSubjects != null && SelectedGroup != null)
				{
					var tmpData = _ujc.University_Subject.ToList();
					var teach = _ujc.University_Group.Where(e => e.Group_ID == SelectedGroup.Group_ID).FirstOrDefault();
					var exclData = teach.University_Subject.ToList();
					var res = tmpData.Except(exclData).ToList();
					AllSubjects = new ObservableCollection<University_Subject>(res);
				}
			}
		}

		void GetCurrentStudents(University_Group obj)
		{
			if (obj!=null)
			{
				using (_ujc = new UniversityEntities())
				{
					var _studs = _ujc.University_Group.Where(gr => gr.Group_ID == obj.Group_ID).FirstOrDefault();
					Students = new ObservableCollection<University_Student>(_studs.University_Student.ToList());
				}
			}
		}

		private void GetAllStudents()
		{
			AllAvailableStudents = new ObservableCollection<University_Student>();
			using(_ujc = new UniversityEntities())
			{
				var _allStuds = _ujc.University_Student.Select(s => s);
				foreach(var stud in _allStuds)
				{
					if (stud.University_Group.Count==0)
					{
						AllAvailableStudents.Add(stud);
					}
				}
			}
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
