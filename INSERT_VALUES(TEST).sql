USE University
GO

/*Add teachers*/
insert into University_Teacher (First_Name,Last_Name,Email,Birthday)
values ('Petro', 'Petrenko','p.petrenko@uni.com','1979-12-12'),
		('Ivan','Ivanenko','i.ivanenko@uni.com','1980-01-01'),
		('Semen','Semenchenko','s.semenchenko@uni.com','1981-03-03')

/*Add subjects*/
insert into University_Subject (Subject_Name)
values ('Chemistry'),
		('Mathematics'),
		('Physics'),
		('English'),
		('.NET Core')

/*Connect teacher-subject*/
insert into University_TeaSubj (Teacher_ID,Subject_ID)
values (1,0),
(1,1),
(2,3),
(2,2),
(3,2),
(3,1),
(3,4)

/*Add Students*/
insert into University_Student(First_Name,Last_Name,Email,Birthday)
values ('Stud1','Studenko1','stud1@gmail.com','1996-01-01'),
		('Stud2','Studenko2','stud2@gmail.com','1995-01-01'),
		('Stud3','Studenko3','stud3@gmail.com','1994-01-01'),
		('Stud4','Studenko4','stud4@gmail.com','1993-01-01'),
		('Stud5','Studenko5','stud5@gmail.com','1992-01-01')

/*Add groups*/
insert into University_Group(Group_Name)
values ('Group1'),
		('Group2'),
		('Group3')

/*Add students to groups*/
insert into University_StudGroup (Group_ID,Student_ID)
values (0,0),
(1,1),
(2,2),
(0,3),
(1,4)

/*Add Subjects to Groups*/
insert into University_GroupSubj (Group_ID,Subject_ID)
values (0,0),(0,1),(0,2),(1,2),(1,3),(1,4),(2,0),(2,2),(2,4)

/*Add records to Schedules*/
insert into University_Schedule (Day_of_week,LessonNo,Group_ID,Subject_ID,Teacher_ID)
values
('Monday',1,0,2,2),
('Monday',1,1,4,3),
('Monday',1,2,0,1),
('Monday',2,0,1,3),
('Monday',2,1,2,2)


/*Example of Select query*/
/*select a.Day_of_week, a.LessonNo, b.Group_Name,c.Subject_Name,d.First_Name,d.Last_Name
from University_Schedule a, University_Group b, University_Subject c, University_Teacher d
where a.Group_ID=b.Group_ID and a.Subject_ID=c.Subject_ID and a.Teacher_ID=d.Teacher_ID*/