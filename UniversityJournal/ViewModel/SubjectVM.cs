using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityJournal.Model;

namespace UniversityJournal.ViewModel
{
	class SubjectVM:BaseViewModel,ITabConfig
	{
		
		private List<University_Subject> _subjects;
		private University_Subject _selectedSubject;

		
		private string _newSubject;
		private string _currentSubject;

		private Command<object> _addNewSubject;
		private Command<University_Subject> _deleteSubject;
		private Command<University_Subject> _editSubject;

		

		public string TabName { get; set; }
		public List<University_Subject> Subjects
		{
			get
			{return _subjects;}
			set
			{
				_subjects = value;
				RaisePropertyChanged("Subjects");
			}
		}

		public string NewSubject
		{
			get { return _newSubject; }
			set
			{
				_newSubject = value;
				RaisePropertyChanged("NewSubject");
			}
		}

		public Command<object> AddNewSubject
		{
			get { return _addNewSubject; }
		}

		public Command<University_Subject> DeleteSubject
		{
			get { return _deleteSubject; }
		}

		public Command<University_Subject> EditSubject
		{
			get { return _editSubject; }
		}

		public University_Subject SelectedSubject
		{
			get { return _selectedSubject; }
			set 
			{
				_selectedSubject = value;
				RaisePropertyChanged("SelectedSubject");
				if (value != null)
				{
					CurrentSubject = value.Subject_Name;
					RaisePropertyChanged("CurrentSubject");
				}
			}
		}

		public string CurrentSubject
		{
			get { return _currentSubject; }
			set 
			{ 
				_currentSubject = value;
				RaisePropertyChanged("CurrentSubject");
			}
		}

		public SubjectVM()
		{
			TabName = "Subjects";
			_addNewSubject = new Command<object>(AddNewSubjectToDB,
				(s) => { return !string.IsNullOrWhiteSpace(NewSubject); });

			_deleteSubject = new Command<University_Subject>(DeleteSubjectFromDB,
				s => s!= null);
			_editSubject = new Command<University_Subject>(EditSubjectFromDB,
				s => s != null);
			UpdateSubjects();
			
			
		}

		void AddNewSubjectToDB(object parameter)
		{
			using (_ujc = new UniversityEntities())
			{
				_ujc.University_Subject.Add(new University_Subject()
											{Subject_Name = NewSubject });
				_ujc.SaveChanges();
			}
			NewSubject = null;
			UpdateSubjects();
		}

		
		void DeleteSubjectFromDB(University_Subject parameter)
		{
			using (_ujc = new UniversityEntities())
			{
				var tmp = _ujc.University_Subject.Where(s => s.Subject_ID == parameter.Subject_ID).FirstOrDefault();

				if (tmp != null)
				{
					_ujc.University_Subject.Remove(tmp);
					_ujc.SaveChanges();
					SelectedSubject = null;
					UpdateSubjects();
				}
			}
		}

		private void EditSubjectFromDB(University_Subject obj)
		{
			using (_ujc = new UniversityEntities())
			{
				var subj = _ujc.University_Subject.Where(s => s.Subject_ID == obj.Subject_ID).FirstOrDefault();
				if (subj != null)
				{
					subj.Subject_Name = CurrentSubject;
					_ujc.SaveChanges();
				}
				UpdateSubjects();
			}
		}

		void UpdateSubjects()
		{
			using (_ujc = new UniversityEntities())
			{
				_subjects = (from subj in _ujc.University_Subject
							 select subj).ToList();
				RaisePropertyChanged("Subjects");
			}
		}
		public System.Windows.Visibility Vis
		{
			get;
			set;
		}

		public void Refresh()
		{
			UpdateSubjects();
		}
	}
}
