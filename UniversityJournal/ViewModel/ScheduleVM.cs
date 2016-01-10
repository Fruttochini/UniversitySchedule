using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UniversityJournal.Model;

namespace UniversityJournal.ViewModel
{
	class ScheduleVM:BaseViewModel,ITabConfig
	{
#region Schedule days (variables and properties)
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

		
#endregion
#region Filter Functionality
		private ObservableCollection<University_Group> _filterList;
		private University_Group _selectedFilter;
		public ObservableCollection<University_Group> FilterList
		{
			get { return _filterList; }
			set { _filterList = value;
			RaisePropertyChanged("FilterList");
			}
		}
		public University_Group SelectedFilter
		{
			get { return _selectedFilter; }
			set 
			{
				_selectedFilter = value;
				RaisePropertyChanged("SelectedFilter");
				UpdateSchedule();	
			}
		}

#endregion


#region Addition variables and properties
		private ObservableCollection<string> _days;
		private ObservableCollection<int> _lessonNums;
		private ObservableCollection<University_Group> _availableGroups;
		private ObservableCollection<University_Subject> _GroupSubjects;
		private ObservableCollection<University_Teacher> _Teachers;
		
		public ObservableCollection<string> Days
		{
			get { return _days; }
			set { _days = value; RaisePropertyChanged("Days"); }
		}
		public ObservableCollection<int> LessonNums
		{
			get { return _lessonNums; }
			set { _lessonNums = value; RaisePropertyChanged("LessonNums"); }
		}
		public ObservableCollection<University_Group> AvailableGroups
		{
			get { return _availableGroups; }
			set { _availableGroups = value; RaisePropertyChanged("AvailableGroups"); }
		}
		public ObservableCollection<University_Subject> GroupSubjects
		{
			get { return _GroupSubjects; }
			set { _GroupSubjects = value; RaisePropertyChanged("GroupSubjects"); }
		}
		public ObservableCollection<University_Teacher> Teachers
		{
			get { return _Teachers; }
			set { _Teachers = value; RaisePropertyChanged("Teachers");}
		}

		private string _selectedDay;
		private int _selectedLessonNo;
		private University_Group _selectedGroup;
		private University_Subject _selectedSubject;
		private University_Teacher _selectedTeacher;

		public string SelectedDay
		{
			get { return _selectedDay; }
			set { _selectedDay = value;
			RaisePropertyChanged("SelectedDay");
			SelectedLessonNo = 1;
			SelectedFilter = FilterList[0];
			}
		}
		public int SelectedLessonNo
		{
			get { return _selectedLessonNo; }
			set { _selectedLessonNo = value;
				RaisePropertyChanged("SelectedLessonNo");
				OnSelectedLessonNo();
				SelectedFilter = FilterList[0];
				SelectedGroup = null;
			}
		}
		public University_Group SelectedGroup
		{
			get { return _selectedGroup; }
			set { _selectedGroup = value; 
				RaisePropertyChanged("SelectedGroup");
				OnSelectedGroup();
				SelectedSubject = null;
			}
		}
		public University_Subject SelectedSubject
		{
			get { return _selectedSubject; }
			set { _selectedSubject = value; 
				RaisePropertyChanged("SelectedSubject");
				OnSelectedSubject();
				SelectedTeacher = null;
			}
		}
		public University_Teacher SelectedTeacher
		{
			get { return _selectedTeacher; }
			set { _selectedTeacher = value; 
				RaisePropertyChanged("SelectedTeacher"); }
		}
		private void OnSelectedLessonNo()
		{
			if (!string.IsNullOrEmpty(SelectedDay)&&SelectedLessonNo>0&&SelectedLessonNo<5)
			{
				using (_ujc = new UniversityEntities())
				{
					AvailableGroups = new ObservableCollection<University_Group>();
					var _exclgrID = _ujc.University_Schedule
						.Where(s=>s.Day_of_week.Equals(SelectedDay))
						.Where(s=>s.LessonNo==SelectedLessonNo)
						.Select(s=>s.Group_ID);
					var _allgrID = _ujc.University_Group
						.Select(s=>s.Group_ID);
					var _availgrID = _allgrID.Except(_exclgrID);
					foreach (var id in _availgrID)
					{
						AvailableGroups.Add(_ujc.University_Group.Where(gr => gr.Group_ID == id).FirstOrDefault());
					}
					
				}
			}
		}
		private void OnSelectedGroup()
		{
			if (!string.IsNullOrEmpty(SelectedDay) 
				&& SelectedLessonNo > 0 
				&& SelectedLessonNo < 5 
				&& SelectedGroup != null)
			{
				using (_ujc = new UniversityEntities())
				{
					var _selgr = _ujc.University_Group
						.Where(s => s.Group_ID == SelectedGroup.Group_ID).FirstOrDefault();
					var _subjs = _selgr.University_Subject.ToList();
					GroupSubjects = new ObservableCollection<University_Subject>(_subjs);
				}
			}
		}
		private void OnSelectedSubject()
		{
			if (!string.IsNullOrEmpty(SelectedDay) && SelectedLessonNo > 0 && SelectedLessonNo < 5 && SelectedGroup != null&& SelectedSubject!=null)
			{
				using (_ujc = new UniversityEntities())
				{
					var _ss = _ujc.University_Subject.Where(s => s.Subject_ID == SelectedSubject.Subject_ID).FirstOrDefault();
					var _exclTchrID = _ujc.University_Schedule
						.Where(s=>s.Day_of_week==SelectedDay)
						.Where(s=>s.LessonNo==SelectedLessonNo)
						.Select(s => s.Teacher_ID);
					var _possTchrID = _ss.University_Teacher.Select(s => s.Teacher_ID);
					var _availTchrID = _possTchrID.Except(_exclTchrID);
					Teachers = new ObservableCollection<University_Teacher>();
					foreach (var id in _availTchrID)
					{
						Teachers.Add(_ujc.University_Teacher.Where(tch => tch.Teacher_ID == id).FirstOrDefault());
					}
				}
			}
		}

#endregion

#region Commands
		private Command<Schedule> _deleteLesson;
		public Command<Schedule> DeleteLesson
		{
			get { return _deleteLesson; }
		}
		private void DeleteLessonFromSchedule(Schedule parameter)
		{
			using (_ujc = new UniversityEntities())
			{
				var _delLes = _ujc.University_Schedule.Where(s => s.Lesson_ID == parameter.Lesson_ID).FirstOrDefault();
				_ujc.University_Schedule.Remove(_delLes);
				_ujc.SaveChanges();
			}
			UpdateSchedule();
		}

		private Command<object> _addLesson;
		public Command<object> AddLesson
		{
			get { return _addLesson; }
		}
		private void AddLessonToSchedule(object parameter)
		{
			using (_ujc = new UniversityEntities())
			{
				var _newLes = new University_Schedule();
				_newLes.Day_of_week = SelectedDay;
				_newLes.LessonNo = SelectedLessonNo;
				_newLes.Group_ID = SelectedGroup.Group_ID;
				_newLes.Subject_ID = SelectedSubject.Subject_ID;
				_newLes.Teacher_ID = SelectedTeacher.Teacher_ID;
				_ujc.University_Schedule.Add(_newLes);
				_ujc.SaveChanges();
			}
			SelectedLessonNo = 0;
			RaisePropertyChanged("SelecteLessonNo");
			SelectedDay = null;
			OnSelectedLessonNo();
			UpdateSchedule();
			
		}

		
#endregion
		public string TabName { get; set; }
		
		public ScheduleVM()
		{
			_deleteLesson = new Command<Schedule>(DeleteLessonFromSchedule);
			_addLesson = new Command<object>(AddLessonToSchedule,
				s =>
				{
					return !string.IsNullOrEmpty(SelectedDay)
						&& SelectedLessonNo > 0
						&& SelectedLessonNo < 5
						&& SelectedGroup != null
						&& SelectedSubject != null
						&& SelectedTeacher != null;
				}
				);
			
			Days = new ObservableCollection<string>();
			Days.Add("Monday");
			Days.Add("Tuesday");
			Days.Add("Wednesday");
			Days.Add("Thursday");
			Days.Add("Friday");

			LessonNums = new ObservableCollection<int>();
			LessonNums.Add(1);
			LessonNums.Add(2);
			LessonNums.Add(3);
			LessonNums.Add(4);

			Refresh();
			//using (_ujc = new UniversityEntities())
			//{
			//	FilterList = new ObservableCollection<University_Group>();
			//	FilterList.Add(new University_Group() { Group_Name = "ALL", Group_ID = 65536 });
			//	foreach (var gr in _ujc.University_Group.Select(s => s).ToList())
			//	{
			//		FilterList.Add(gr);
			//	}
			//	SelectedFilter = FilterList[0];
			//}

			//UpdateSchedule();
		}
	
		private void UpdateSchedule()
		{
			using (_ujc=new UniversityEntities())
			{
				
				UpdateDaySchedule("Monday", ref _mondayLessons);
				UpdateDaySchedule("Tuesday", ref _tuesdayLessons);
				UpdateDaySchedule("Wednesday", ref _wednesdayLessons);
				UpdateDaySchedule("Thursday", ref _thursdayLessons);
				UpdateDaySchedule("Friday", ref _fridayLessons);
				RaisePropertyChanged("MondayLessons");
				RaisePropertyChanged("TuesdayLessons");
				RaisePropertyChanged("WednesdayLessons");
				RaisePropertyChanged("ThursdayLessons");
				RaisePropertyChanged("FridayLessons");
				
				
			}
		}

		private void UpdateDaySchedule(string DayOfWeek, ref ObservableCollection<Schedule> DayLessons)
		{
			DayLessons = new ObservableCollection<Schedule>();
			var tmp = _ujc.Schedule
				.Where(s => s.Day_of_week == DayOfWeek);
			if (SelectedFilter != null&&SelectedFilter.Group_ID != 65536)
			{
				tmp = tmp.Where(s=>s.Group_Name==SelectedFilter.Group_Name);
			}
				var _grles=tmp.GroupBy(les => les.LessonNo).ToList();
			foreach (var item in _grles)
			{
				foreach (var it in item)
				{
					DayLessons.Add(it);
				}
			}
		}

		
		private Visibility _vis;
		public System.Windows.Visibility Vis
		{
			get { return _vis; }
			set { _vis = value; RaisePropertyChanged("Vis"); }
		}

		public void Refresh()
		{
			
			FilterList = new ObservableCollection<University_Group>();
			FilterList.Add(new University_Group() { Group_Name = "ALL", Group_ID = 65536 });

			using (_ujc = new UniversityEntities())
			{
				foreach (var gr in _ujc.University_Group.Select(s => s).ToList())
				{
					FilterList.Add(gr);
				}
				SelectedFilter = FilterList[0];
			}
			UpdateSchedule();
			
		}
	}
}
