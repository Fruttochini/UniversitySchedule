   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity   UniversityJournal'   !UniversityJournal.View.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity       � Title$  
MainWindow��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=�
�������.���  � RowDefinitions �� $
��Auto ��� .+��� $��0�� �� Orientation$ 
Horizontal=�$��5,5,5,2q�.+��� $��Logged in as: ��$��Center=��� $��12(�$
��Bold"�
����  �$��Center=����� *
LoggedIn+�� -   $��Log Out��$��Center=��� $��1��
������� �� SelectedIndex ��  �� Path$ SelectIndex�.@��� -    ��Name$ SchedTab�� � DataContext �� *schdVM+���� $ TabName�y��� $	 Vis�.���  � 	Resources    DeleteButton	 �� 
TargetType
 �� Property �� Value �� ElementName  ScheduleHeaders��%�   &	        &	 �     �� "	 ��.��� 
 � �� �� $ SchedTab��$ DataContext.DeleteLesson��� 
 � �� �� �� 
 � ��$ -���� 
 � ��$ 20���� "	 ��.��� 
 � ��$ Center=��� 
 � ��$ 12(��� 
 � ��$	 Top=� �� $
��Auto ��� ��  � ColumnDefinitions �� �� �� �� �� .+�]� $��1��$��0��.+��� $��Monday��#��[ �� ���� *MondayLessons+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+�� $	�� - ���� ���� *	Teacher+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+�� #��[  ]� $��1��$��1��.+��� $��Tuesday��#��[ �� ���� *TuesdayLessons+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+�� $	�� - ���� ���� *	Teacher+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+�� #��[  ]� $��1��$��2��.+��� $��	Wednesday��#��[ �� ���� *WednesdayLessons+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+�� $	�� - ���� ���� *	Teacher+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+�� #��[  ]� $��1��$��3��.+��� $��Thursday��#��[ �� ���� *ThursdayLessons+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+�� $	�� - ���� ���� *	Teacher+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+�� #��[  ]� $��1��$��4��.+��� $��Friday��#��[ �� ���� *FridayLessons+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+�� $	�� - ���� ���� *	Teacher+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+�� #��[  �� $��0��$��0��.+��� $��Select Group:���� ���� *
FilterList+ �� SelectedItem �� *SelectedFilter+���� .R��� ���� *
Group_Name+9� $��2��$��0��$��5��$��Add Lessons��.���    ListViewStyle��%?   &	       �� "	 ��.��� 
 �@��SelectionMode$ Single=� �� �� �� �� �� �� .+�]� $��0��.+��� $��Choose Day:��$	��Top=��� #��[ ���� *Days+ �� *SelectedDay+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�]� $��1��.+��� $��Choose Lesson No.:��$	��Top=��� #��[ ���� *
LessonNums+ �� *SelectedLessonNo+$ TwoWay=�$ PropertyChanged=�]� $��2��.+��� $��Choose Group:��$	��Top=��� #��[ ���� *AvailableGroups+ �� *SelectedGroup+$ TwoWay=�$ PropertyChanged=����� .R��� ���� *
Group_Name+]� $��3��.+��� $��Choose Subject:��$	��Top=��� #��[ ���� *GroupSubjects+ �� *SelectedSubject+$ TwoWay=�$ PropertyChanged=����� .R��� ���� *Subject_Name+]� $��4��.+��� $��Choose Teacher:��$	��Top=��� #��[ ���� *
Teachers+ �� *SelectedTeacher+$ TwoWay=�$ PropertyChanged=����� .R��� $ 
Horizontal=�.+��� ���� *
First_Name+�� $�� ���� ���� *	Last_Name+�� $��5��$��
Add Lesson��$�� ��$��50������ *	AddLesson+��  �� *gvm+���� $ TabName�y��� $	 Vis�.���  �� �� ��  �� $
��Auto ��� �� .+�� $��0��$��0��$��3�� �� �� $
��Auto �.+��� -    ��Name$ AllGroupList��$��0������ *Groups+ �� *SelectedGroup+$ PropertyChanged=�$ TwoWay=����� .R��� ���� *
Group_Name+�� $��1��$��Delete��$��30������ *DeleteGroup+���� $ AllGroupList��$ SelectedItem��� $��0��$��1��$��
10,0,10,10q�.+��� $��Edit current Group name:���� ���� *GroupNameEdit+$ PropertyChanged=�$ TwoWay=��� $
��Edit������ *	EditGroup+���� $ AllGroupList��$ SelectedItem��� $��0��$��2��$��
10,0,10,10q�.+��� $��Add new Group:���� -    ��Name$ NewGroupName���� $	��Add������ *AddNewGroup+���� $ NewGroupName��$
 Text�� $��1��$��1��$��2�� �� �� $
��Auto ��� .+�]� $��0��$��0��$��	10,5,0,10q�.+��� $��Current Subjects:��$	��Top=��� -   $ GroupsSubjectLst������ *CurrentSubjects+���� .R��� ���� *Subject_Name+�� $��0��$��1��$��Center=�$��5q�.+��� $��->��$��30��$��5q����� *RemoveSubject+���� $ GroupsSubjectLst��$ SelectedItem��� $��<-��$��30��$��5q����� *
AddSubject+���� $ AllGroupsSubjectLst��$ SelectedItem�]� $��0��$��2��$��	0,5,10,10q�.+��� $��All Subjects:��$	��Top=��� -   $ AllGroupsSubjectLst������ *AllSubjects+���� .R��� ���� *Subject_Name+� $��2��$��1��$��2�� �� �� $
��Auto ��� .+�]� $��0��$��0��$��	10,5,0,10q�.+��� $��Current Students:��$	��Top=��� -   $ GroupCurStudents��$��0������ *
Students+ �� View ��  �� AllowsColumnReorder .  .P��� $	��No.�� �� DisplayMemberBinding �� *
Student_ID+�� $��	Last Name�� �� *	Last_Name+�� $��
First Name�� �� *
First_Name+�� $��0��$��1��$��Center=�$��5q�.+��� $��->��$��30��$��5q����� *RemoveStudents+���� $ GroupCurStudents��$ SelectedItem��� $��<-��$��30��$��5q����� *AddStudents+���� $ AllAvailableStudents��$ SelectedItem�]� $��0��$��2��$��	10,5,0,10q�.+��� $��Students w/o group:��$	��Top=��� -   $ AllAvailableStudents��$��0������ *AllAvailableStudents+ ��  .  .P��� $	��No.�� �� *
Student_ID+�� $��	Last Name�� �� *	Last_Name+�� $��
First Name�� �� *
First_Name+��  �� $ TeacVM����� $ TabName�y��� $	 Vis�.���  �� �� ��  �� �� .+�� $��0��$��2��$��0�� �� �� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -	     Name$ TeachersLst��$��0��$��0��   AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     SelectionMode$ Single=�   
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * ���� $ Teachers�{��� $ 	BlockGrid�$ PropertyChanged=� �� *SelectedTeacher+$ PropertyChanged=�$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��    Width$
  Auto 1  +System.Windows.Controls.DataGridBoundColumn!   Binding! �� *
Teacher_ID+  $ 
First Name��! �� *
First_Name+  $ 	Last Name��! �� *	Last_Name+�� $��Delete��$��1��$��30������ *DeleteTeacher+���� $ TeachersLst��$ SelectedItem�� $��0��$��1��$��2��   EditEnabled3  AllowEditOperation  AllowAddOperation��%   &	       &	 I     &	 �     �� "	 ��.��� 
 � {� �� *EditEnabled+$ PropertyChanged=��� "	 ��.��� 
 � {� �� *AllowEditButton+$ PropertyChanged=��� "	 ��.��� 
 � {� �� *AllowAddButton+$ PropertyChanged=� �� $
��Auto ��� �� $
��Auto �.+��� $��0��$��Info:��$��Center=�� $��1��{���    EditEnabled1  EditEnabled2(  "System.Windows.Controls.DatePicker��%   &	       &	 v     �� "	 ��.��� 
 � {� �� *EditEnabled+$ PropertyChanged=��� 
 � ��$ 25���� 
 � ��$	 Top=��� "	  .��� 
 � {� �� *EditEnabled+$ PropertyChanged=��� 
 � ��$ 25���� 
 � ��$	 Top=� �� �� �� �� ��  �� $
��Auto ��� �� �� .+��� $��Name:��$��0��$��0���� $��
Last name:��$��1��$��0���� $��Birth date:��$��2��$��0���� $��Email:��$��3��$��0���� $��0��$��1��#��[ ���� *Tname+$ PropertyChanged=��� $��1��$��1��#��[ ���� *Tlname+$ PropertyChanged=�  $��2��$��1��#��[ "   SelectedDate" �� *Tbdate+$ PropertyChanged=��� $��3��$��1��#��[ ���� *Temail+$ PropertyChanged=��� $��0��$��2��$��4��$��10q����� *Tphoto+�� $��	Browse...��$�� ��#��[ $��4��$��2��$��60��$��25��$	��Top=����� *BrowseButton+$ PropertyChanged=��� $��0��$��5��$��3��.+��� $��Login:���� #��[ ���� *Tlogin+$ PropertyChanged=��� $��	Password:���� #��[ ���� *Tpwd+$ PropertyChanged=�� $��2��$��10q� �� �� .+��� $��0��$�� ��#���  ���� *AddButtonName+���� *AddNewTeacher+$ PropertyChanged=��� $��1��#���  ���� *EditButtonName+���� *EditTeacher+$ PropertyChanged=����� $ TeachersLst��$ SelectedItem�� $��1��$��1��$��2�� �� �� $
��Auto � �� �� $
��Auto ��� .+�]� $��0��$��0��$��5,5,0,10q�.+��� $��Current Subjects:��$	��Top=��� -
   $ 
CurSubjLst������ *CurrentSubjects+���� .R��� ���� *Subject_Name+�� $��0��$��1��$��Center=�$��5q�.+��� $��->��$��30��$��5q����� *RemoveSubject+���� $ 
CurSubjLst��$ SelectedItem��� $��<-��$��30��$��5q����� *
AddSubject+���� $ AllSubjList��$ SelectedItem�]� $��0��$��2��$��0,5,5,10q�.+��� $��All Subjects:��$	��Top=��� -   $ AllSubjList������ *AllSubjects+���� .R��� ���� *Subject_Name+�� ���� $ subjvm.TabName�y��� $ 
subjvm.Vis�.���  �� �� ��  �� �� $
��Auto �.+�  -   $ SubjectsLst��$��0��$��0��$��2�� .   .   .   .   . $ Single=�$ * ���� *subjvm.Subjects+ �� *subjvm.SelectedSubject+$ PropertyChanged=�   $ Subject No.��$
  Auto ! �� *
Subject_ID+  $ Subject��! �� *Subject_Name+�� $��1��$��Delete��$��30������ *subjvm.DeleteSubject+���� $ SubjectsLst��$ SelectedItem��� $��0��$��1��$��10q�.+��� $��Edit current subject:��]� ��. .+��� $	��ID:���� ���� *#!subjvm.SelectedSubject.Subject_ID+�� ���� *subjvm.CurrentSubject+$ PropertyChanged=�$ TwoWay=��� $
��Edit������ *subjvm.EditSubject+���� $ SubjectsLst��$ SelectedItem��� $��0��$��2��$��10q�.+��� $��Add new subject:���� ���� *subjvm.NewSubject+$ PropertyChanged=�$ TwoWay=��� $	��Add��$�� ������ *subjvm.AddNewSubject+�� ���� *Studvm.TabName+y��� $ 
Studvm.Vis�.���  �� $
��Auto ��� �� $
��Auto � �� .+��� $��0��$ 
Horizontal=�.+��� $��Search:���� $	��100������ *Studvm.SearchString+$ PropertyChanged=�$ TwoWay=�  -   $ StudLst��$��1��$��0��$��2�� .   .   .   .   . $ * $ Single=����� *Studvm.Students+ �� *Studvm.SelectedStudent+   $ Student No.��$
  Auto ! �� *
Student_ID+  $ 
First Name��! �� *
First_Name+  $ 	Last Name��! �� *	Last_Name+  $ 	Birthdate��! �� *
Birthday+5  /System.Windows.Controls.DataGridHyperlinkColumn  $ Email��! �� *Email+� $��2�� �� �� �� .+��� $	��Add��$��0��$�� ������ *Studvm.AddNewStudent+�� $
��Edit��$��1������ *Studvm.EditStudent+���� $ StudLst��$ SelectedItem��� $��Delete��$��2������ *Studvm.DeleteStudent+���� $ StudLst��$ SelectedItem���  �� *
TeachIntVM+���� *	TabName+y��� $	 Vis�.���  ��%^   &	       �� "	 ��.��� 
 � ��$ Center=��� 
 � ��$ 12(��� 
 � ��$	 Top=� �� $
��Auto ��� $
��Auto ���  �� �� �� �� �� .+��� $��0��$��0��$��2��.+��� $��Current date:���� $��14(�$
��Bold"����� *
TodaysDate+9� $��1��$��0��$��5��$��Select Lesson��# 9� 
IsExpanded# . .���  �� $
��Auto ���  �� �� �� �� �� .+�]� $��1��$��0��.+��� $��Monday��#��[ �� ���� *MondayLessons+ �� *SelectedLesson+���� *
MonThick+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+]� $��1��$��1��.+��� $��Tuesday��#��[ �� ���� *TuesdayLessons+ �� *SelectedLesson+���� *
TueThick+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+]� $��1��$��2��.+��� $��	Wednesday��#��[ �� ���� *WednesdayLessons+ �� *SelectedLesson+���� *
WedThick+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+]� $��1��$��3��.+��� $��Thursday��#��[ �� ���� *ThursdayLessons+ �� *SelectedLesson+���� *	ThurThick+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+]� $��1��$��4��.+��� $��Friday��#��[ �� ���� *FridayLessons+ �� *SelectedLesson+���� *
FriThick+���� .R�]� .+��� $ 
Horizontal=�$	��Top=�.+��� $
��Bold"����� *
LessonNo+�� $	�� - ���� $
��Bold"����� *
Group_Name+]� $��Bottom=�.+��� $
��Bold"�$
��Left=����� *Subject_Name+�� $��2��$��2��$��5,10,5,0q�.+��� $ 
Horizontal=�.+��� $
��Bold"����� *SelectedLesson.Day_of_week+�� $��, Lesson No. ���� $
��Bold"����� *SelectedLesson.LessonNo+�� $��	, Group: ���� $
��Bold"����� *SelectedLesson.Group_Name+�� $��, Subject: ���� $
��Bold"����� *SelectedLesson.Subject_Name+�� $ �� SelectionMode$$ Single=����� *LessonStudents+ �� *SelectedStudent+$ TwoWay=�$ PropertyChanged=� �� .P��� $	��No.�� �� *
Student_ID+�� $��	Last Name�� �� *	Last_Name+�� $��
First Name�� �� *
First_Name+� $��2��$��2��$��5,10,5,0q�$��3�� �� $
��Auto ��� $
��Auto ��� .+��� $��0��$ 
Horizontal=�.+��� $��Select Date of Lesson:��$��Center=�  $��Center=�" �� *
LessonDate+�� $��1��{��� *CanEditStudentMark+.+��� $ 
Horizontal=�.+��� ���� *SelectedStudent.First_Name+�� $�� ���� ���� *SelectedStudent.Last_Name+�� -   % ��Name$% StudPres��$��Present?��& d� 	IsChecked& �� *StudentPresent+�� $ 
Horizontal=�.+��� $
��Mark��$��Center=��� $��20��$��Center=����� *StudentMark+$ PropertyChanged=�{��� $ StudPres��$ 	IsChecked��� $
��Save��$
��Left=�$��80������ *SaveStudentState+���� *SelectedStudent+�� ���� *
SaveInfo+�� $��2��$$ Single=����� *CurrentLessonPresence+ �� .P��� $��	Last Name�� �� *	Last_Name+�� $��
First Name�� �� *
First_Name+�� $��Present?�� �� *	Present+�� $
��Mark�� �� *Mark+