-- select master
use master

--create db
create database dbSample17Jan22

--selecet the db   
use dbSample17Jan22

-- create table
create table tblLocation
(locationName varchar(20) primary key,
zipcode varchar(5))

--show table desc
--sp_Help tblLocation

alter table tblLocation
add anotherColumn int

alter table	tblLocation
drop column anotherColumn

drop table tblLocation

create table tblEmployee
(EmployeeID int identity(101,1) primary key,  --seed/starting val 101, increase by 1
Name varchar(20) not null,
Phone varchar(15),
Location varchar(20) references tblLocation(locationName),  --long ver. Location varchar(20) foreign key fk_EmpLocation references tblLocation(locationName),
Age int,
Email varchar(100),
JoiningDate DateTime,
Role varchar(15) check (role in ('Manager','Developer', 'Sr. Developer','Tester' ))
)

--sp_Help tblEmployee

create table tblSkill
(skillName varchar(20) constraint pk_skill primary key,
skillDescription varchar(100))

create table tblEmployeeSkill
(EmpID int constraint fk_empSkill foreign key references tblEmployee(EmployeeID),
Skill varchar(20) references tblSkill(skillName),
SkillLevel float,
primary key(EmpID, Skill))
