create database University
go

use University;

create table University_Teacher
(Teacher_ID int not null primary key identity(0000,1),
First_Name nvarchar(15) not null,
Last_Name nvarchar(30) not null,
Email nvarchar(50),
Birthday Date not null default '1970-01-01',
Photo varbinary(max)
)

create table University_Subject
(Subject_ID int not null primary key identity(0000,1),
Subject_Name nvarchar(25) not null unique,
)

create table University_TeaSubj
(Teacher_ID int not null foreign key references University_Teacher(Teacher_ID),
Subject_ID int not null foreign key references University_Subject(Subject_ID)
)

create table University_Student
(Student_ID int not null primary key identity(0000,1),
First_Name nvarchar(15) not null,
Last_Name nvarchar(30) not null,
Email nvarchar(50),
Birthday Date not null default '1996-01-01',
Photo varbinary(max)
)

create table University_Group
(Group_ID int not null primary key identity(0000,1),
Group_Name nvarchar(8) not null unique,
)

create table University_StudGroup
(Group_ID int not null foreign key references University_Group(Group_ID),
Student_ID int not null foreign key references University_Student(Student_ID)
)

create table University_GroupSubj
(Group_ID int not null foreign key references University_Group,
Subject_ID int not null foreign key references University_Subject
)

create table University_Schedule
(Lesson_ID int not null primary key identity(0000,1),
Day_of_week nvarchar(10) not null,
LessonNo int not null,
Group_ID int not null foreign key references University_Group(Group_ID),
Teacher_ID int not null foreign key references University_Teacher(Teacher_ID),
Subject_ID int not null foreign key references University_Subject(Subject_ID)
)