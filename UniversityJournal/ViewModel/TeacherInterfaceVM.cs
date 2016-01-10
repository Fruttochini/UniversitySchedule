using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityJournal.Model;

namespace UniversityJournal.ViewModel
{
	class TeacherInterfaceVM:BaseViewModel,ITabConfig
	{
		private ObservableCollection<Schedule> _mondayLessons;
		private ObservableCollection<Schedule> _tuesdayLessons;
		private ObservableCollection<Schedule> _wednesdayLessons;
		private ObservableCollection<Schedule> _thursdayLessons;
		private ObservableCollection<Schedule> _fridayLessons;
		public ObservableCollection<Schedule> MondayLessons
		{
			get { return _mondayLessons; }
			set { _mondayLessons = value; RaisePropertyChanged("MondayLessons"); }
		}
		public ObservableCollection<Schedule> TuesdayLessons
		{
			get { return _tuesdayLessons; }
			set { _tuesdayLessons = value; RaisePropertyChanged("TuesdayLessons"); }
		}
		public ObservableCollection<Schedule> WednesdayLessons
		{
			get { return _wednesdayLessons; }
			set { _wednesdayLessons = value; RaisePropertyChanged("WednesdayLessons"); }
		}
		public ObservableCollection<Schedule> ThursdayLessons
		{
			get { return _thursdayLessons; }
			set { _thursdayLessons = value; RaisePropertyChanged("ThursdayLessons"); }
		}
		public ObservableCollection<Schedule> FridayLessons
		{
			get { return _fridayLessons; }
			set { _fridayLessons = value; RaisePropertyChanged("FridayLessons"); }
		}

		private Command<University_Student> _saveStudentState;

		public Command<University_Student> SaveStudentState
		{
			get { return _saveStudentState; }
		}

		private int _MonThick;

		public int MonThick
		{
			get { return _MonThick; }
			set { _MonThick = value; RaisePropertyChanged("MonThick"); }
		}
		private int _TueThick;

		public int TueThick
		{
			get { return _TueThick; }
			set { _TueThick = value; RaisePropertyChanged("TueThick"); }
		}
		private int _WedThick;

		public int WedThick
		{
			get { return _WedThick; }
			set { _WedThick = value; RaisePropertyChanged("WedThick"); }
		}
		private int _ThurThick;

		public int ThurThick
		{
			get { return _ThurThick; }
			set { _ThurThick = value; RaisePropertyChanged("ThurThick"); }
		}
		private int _FriThick;

		public int FriThick
		{
			get { return _FriThick; }
			set { _FriThick = value; RaisePropertyChanged("FriThick"); }
		}

		private ObservableCollection<University_Student> _LessonStudents;
		public ObservableCollection<University_Student> LessonStudents
		{
			get { return _LessonStudents; }
			set { _LessonStudents = value; RaisePropertyChanged("LessonStudents"); }
		}

		private ObservableCollection<View_StudentPresence> _CurrentLessonPresence;

		public ObservableCollection<View_StudentPresence> CurrentLessonPresence
		{
			get { return _CurrentLessonPresence; }
			set { _CurrentLessonPresence = value; RaisePropertyChanged("CurrentLessonPresence"); }
		}

		private University_Student _selectedStudent;

		public University_Student SelectedStudent
		{
			get { return _selectedStudent; }
			set { _selectedStudent = value; 
				RaisePropertyChanged("SelectedStudent");
				OnSelectedStudentChange();
				SaveInfo = null;
			}
		}

		private string _todaysDate;
		public string TodaysDate
		{
			get { return _todaysDate; }
			set { _todaysDate = value; RaisePropertyChanged("TodaysDate"); }
		}

		private DateTime _lessonDate;
		public DateTime LessonDate
		{
			get { return _lessonDate; }
			set { _lessonDate = value; RaisePropertyChanged("LessonDate");
			SelectedStudent = null;
				CanPutStudentMark();
				OnSelectedLessonChange();
			}
		}

		private string _saveInfo;

		public string SaveInfo
		{
			get { return _saveInfo; }
			set { _saveInfo = value; RaisePropertyChanged("SaveInfo"); }
		}

		private bool _CanEditStudentMark;
		private bool _studentPresent;
		private string _StudentMark;
		public bool StudentPresent
		{
			get { return _studentPresent; }
			set 
			{ 
				_studentPresent = value;
				RaisePropertyChanged("StudentPresent");
				if (!_studentPresent)
				{
					StudentMark = null;
				}
			}
		}
		public string StudentMark
		{
			get { return _StudentMark; }
			set { _StudentMark = value; RaisePropertyChanged("StudentMark"); }
		}
		public bool CanEditStudentMark
		{
			get { return _CanEditStudentMark; }
			set { _CanEditStudentMark = value; RaisePropertyChanged("CanEditStudentMark"); }
		}

		private Schedule _selectedLesson;
		public Schedule SelectedLesson
		{
			get { return _selectedLesson; }
			set {
				_selectedLesson = value;
				RaisePropertyChanged("SelectedLesson");
				OnSelectedLessonChange();
				SelectedStudent = null;
				CanPutStudentMark();
			}
		}

		public string TabName { get; set; }
		public int TeacherID { get; set; }
		
		
		public TeacherInterfaceVM(int tID)
		{
			_saveStudentState = new Command<University_Student>(SaveStudentPresenceAndMark, CanSaveStudentState);
			TeacherID = tID;
			TodaysDate = DateTime.Now.ToString() + ", " + DateTime.Now.DayOfWeek;
			SetBorders();
			UpdateSchedule();
			LessonDate = DateTime.Today;
			CanPutStudentMark();
		}

		private bool CanSaveStudentState(University_Student obj)
		{
			int tmpMark=0;
			bool pars = int.TryParse(StudentMark,out tmpMark);
			return CanPutStudentMark()||(pars&&tmpMark>=0&&tmpMark<=5);
		}

		private void SaveStudentPresenceAndMark(University_Student obj)
		{
			using (_ujc = new UniversityEntities())
			{
				var _StudState = _ujc.University_StudentPresence
						.Where(ls => ls.LessonID == SelectedLesson.Lesson_ID)
						.Where(st => st.StudentID == SelectedStudent.Student_ID)
						.Where(dt => dt.Date == LessonDate.Date).FirstOrDefault();
				if (_StudState != null)
				{
					_StudState.Present = StudentPresent;
					_StudState.Mark = Convert.ToInt32(StudentMark);
				}
				else
				{
					University_StudentPresence tmp = new University_StudentPresence();
					tmp.LessonID = SelectedLesson.Lesson_ID;
					tmp.StudentID = SelectedStudent.Student_ID;
					tmp.Date = LessonDate.Date;
					tmp.Present = StudentPresent;
					tmp.Mark = Convert.ToInt32(StudentMark);
					_ujc.University_StudentPresence.Add(tmp);
				}
				_ujc.SaveChanges();
				SaveInfo = String.Format("Information about {0} {1} has been saved", SelectedStudent.Last_Name, SelectedStudent.First_Name);
				OnSelectedLessonChange();
			}
		}
		
		private void SetBorders()
		{
			MonThick = 1;
			TueThick = 1;
			WedThick = 1;
			ThurThick = 1;
			FriThick = 1;
			switch(DateTime.Today.DayOfWeek)
			{
				case DayOfWeek.Monday:
						MonThick = 3;
						break;
				case DayOfWeek.Tuesday:
						TueThick = 3;
						break;
				case DayOfWeek.Wednesday:
						WedThick = 3;
						break;
				case DayOfWeek.Thursday:
						ThurThick = 3;
						break;
				case DayOfWeek.Friday:
						FriThick = 3;
						break;
				default:
						break;
			}
		}
		private void UpdateSchedule()
		{
			using (_ujc = new UniversityEntities())
			{
				UpdateDaySchedule("Monday", ref _mondayLessons);
				UpdateDaySchedule("Tuesday", ref _tuesdayLessons);
				UpdateDaySchedule("Wednesday", ref _wednesdayLessons);
				UpdateDaySchedule("Thursday", ref _thursdayLessons);
				UpdateDaySchedule("Friday", ref _fridayLessons);
			}
		}

		private void UpdateDaySchedule(string DayOfWeek, ref ObservableCollection<Schedule> DayLessons)
		{
			DayLessons = new ObservableCollection<Schedule>();
			var _teachLessons = _ujc.University_Schedule
				.Where(s => s.Teacher_ID == TeacherID)
				.Where(s=>s.Day_of_week==DayOfWeek)
				.Select(s => s.Lesson_ID);
			var tmp = _ujc.Schedule.ToList();
			foreach (var item in _teachLessons)
			{
				foreach (var it in tmp)
				{
					if (item==it.Lesson_ID)
						DayLessons.Add(it);
				}
			}
		}

		private void OnSelectedLessonChange()
		{
			if (SelectedLesson!=null)
			{
				using (_ujc = new UniversityEntities())
				{
					var _lessonid = _ujc.Schedule.Where(s => s.Lesson_ID == SelectedLesson.Lesson_ID).Select(s => s.Lesson_ID).FirstOrDefault();
					var _groupID = _ujc.University_Schedule.Where(s => s.Lesson_ID == _lessonid).Select(gr => gr.Group_ID).FirstOrDefault();
					var _group = _ujc.University_Group.Where(s => s.Group_ID == _groupID).Select(gr => gr).FirstOrDefault();
					var _studs = _group.University_Student.ToList();
					LessonStudents = new ObservableCollection<University_Student>(_studs);

					var _currles = _ujc.View_StudentPresence
						.Where(ls => ls.LessonID == _lessonid)
						.Where(gr => gr.Group_ID == _groupID)
						.Where(dt => dt.Date == LessonDate.Date).ToList();
					CurrentLessonPresence = new ObservableCollection<View_StudentPresence>(_currles);
				}
			}
		}

		private void OnSelectedStudentChange()
		{
			if (SelectedStudent!=null&&SelectedLesson!=null&&LessonDate!=null)
			{
				using(_ujc=new UniversityEntities())
				{
					var _StudState = _ujc.University_StudentPresence
						.Where(ls => ls.LessonID == SelectedLesson.Lesson_ID)
						.Where(st => st.StudentID == SelectedStudent.Student_ID)
						.Where(dt => dt.Date == LessonDate.Date).FirstOrDefault();
					if (_StudState!=null)
					{
						StudentPresent = _StudState.Present;
						StudentMark = _StudState.Mark.ToString();
					}
					else
					{
						StudentPresent = false;
						StudentMark = null;
					}
				}
				CanPutStudentMark();

			}
		}

		private bool CanPutStudentMark()
		{
			return CanEditStudentMark = SelectedLesson != null
				&& LessonDate != null
				&& LessonDate.DayOfWeek.ToString() == SelectedLesson.Day_of_week
				&& SelectedStudent != null;
		}

		public System.Windows.Visibility Vis
		{
			get;
			set;
		}

		public void Refresh()
		{
			UpdateSchedule();
		}
	}
}
