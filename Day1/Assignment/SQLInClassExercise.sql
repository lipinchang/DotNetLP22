-- select master
use master

--create db
create database dbInClassExercise17Jan22

--selecet the db   
use dbInClassExercise17Jan22

create table tblDepartment
(deptName varchar(20) primary key,
floor int,
phone varchar(2),
empNo int not null,
)


insert into tblDepartment values ('Management',5, 34, 1)
insert into tblDepartment values ('Books',1, 81, 4)
insert into tblDepartment values ('Clothes',2, 24, 4)
insert into tblDepartment values ('Equipment',3, 57, 3)
insert into tblDepartment values ('Furniture',4, 14, 3)
insert into tblDepartment values ('Navigation',1, 41, 3)
insert into tblDepartment values ('Recreation',2, 29, 4)
insert into tblDepartment values ('Accounting',5, 35, 5)
insert into tblDepartment values ('Purchasing',5, 36, 7)
insert into tblDepartment values ('Personnel',5, 37, 9)
insert into tblDepartment values ('Marketing',5, 38, 2)

select * from tblDepartment;

-- create table
create table tblEmp
(empNo  int identity(1,1) primary key,
empName varchar(10),
salary varchar(10),
deptName varchar(20) references tblDepartment(deptName),
bossNo int references tblEmp(empNo)
)


select * from tblEmp

insert into tblEmp (empName, salary, deptName, bossNo)
values ('Alice',75000, 'Management', null)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Ned',45000, 'Marketing', 1)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Andrew',25000, 'Marketing', 2)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Clare',22000, 'Marketing', 2)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Todd',38000, 'Accounting', 1)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Nancy',22000, 'Accounting', 5)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Brier',43000, 'Purchasing', 1)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Sarah',56000, 'Purchasing', 7)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Sophile',35000, 'Personnel', 1)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Sanjay',15000, 'Navigation', 3)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Rita',15000, 'Books', 4)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Gigi',16000, 'Clothes', 4)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Maggie',11000, 'Clothes', 4)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Paul',15000, 'Equipment', 3)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('James',15000, 'Equipment', 3)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Pat ',15000, 'Furniture', 3)
insert into tblEmp (empName, salary, deptName, bossNo)
values ('Mark',15000, 'Recreation', 3)






create table tblItem
(itemName varchar(35) primary key,
itemType char(1) ,
itemColor varchar(10)
)

select * from tblItem

insert into tblItem (itemName, itemType, itemColor)
values ('Pocket Knife-Nile','E', 'Brown')
insert into tblItem (itemName, itemType, itemColor)
values ('Pocket Knife-Avon','E', 'Brown')
insert into tblItem (itemName, itemType, itemColor)
values ('Compass','N', null)
insert into tblItem (itemName, itemType, itemColor)
values ('Geo positioning system','N', null)
insert into tblItem (itemName, itemType, itemColor)
values ('Elephant Polo stick','R', 'Bamboo')
insert into tblItem (itemName, itemType, itemColor)
values ('Camel Saddle','R', 'Brown')
insert into tblItem (itemName, itemType, itemColor)
values ('Sextant','N', null)
insert into tblItem (itemName, itemType, itemColor)
values ('Map Measure','N', null)
insert into tblItem (itemName, itemType, itemColor)
values ('Boots-snake proof','C', 'Green')
insert into tblItem (itemName, itemType, itemColor)
values ('Pith Helmet','C', 'Khaki')
insert into tblItem (itemName, itemType, itemColor)
values ('Hat-polar Explorer','C', 'White')
insert into tblItem (itemName, itemType, itemColor)
values ('Exploring in 10 Easy Lessons','B', null)
insert into tblItem (itemName, itemType, itemColor)
values ('Hammock','F', 'Khaki')
insert into tblItem (itemName, itemType, itemColor)
values ('How to win Foreign Friends','B', null)
insert into tblItem (itemName, itemType, itemColor)
values ('Map case','E', 'Brown')
insert into tblItem (itemName, itemType, itemColor)
values ('Safari Chair','F', 'Khaki')
insert into tblItem (itemName, itemType, itemColor)
values ('Safari cooking kit','F', 'Khaki')
insert into tblItem (itemName, itemType, itemColor)
values ('Stetson','C', 'Black')
insert into tblItem (itemName, itemType, itemColor)
values ('Tent - 2 person','F', 'Khaki')
insert into tblItem (itemName, itemType, itemColor)
values ('Tent - 8 person','F', 'Khaki')


create table tblSales
(salesNo int identity(101,1) primary key,
saleQty int,
itemName varchar(35) not null references tblItem(itemName),
deptName varchar(20) not null references tblDepartment(deptName)
)

select * from tblSales

insert into tblSales(saleQty, itemName, deptName)
values (2, 'Boots-snake proof', 'Clothes')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Pith Helmet', 'Clothes')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Sextant', 'Navigation')
insert into tblSales(saleQty, itemName, deptName)
values (3, 'Hat-polar Explorer', 'Clothes')
insert into tblSales(saleQty, itemName, deptName)
values (5, 'Pith Helmet', 'Equipment')
insert into tblSales(saleQty, itemName, deptName)
values (2, 'Pocket Knife-Nile', 'Clothes')
insert into tblSales(saleQty, itemName, deptName)
values (3, 'Pocket Knife-Nile', 'Recreation')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Compass', 'Navigation')
insert into tblSales(saleQty, itemName, deptName)
values (2, 'Geo positioning system', 'Navigation')
insert into tblSales(saleQty, itemName, deptName)
values (5, 'Map Measure', 'Navigation')

insert into tblSales(saleQty, itemName, deptName)
values (1, 'Geo positioning system', 'Books')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Sextant', 'Books')
insert into tblSales(saleQty, itemName, deptName)
values (3, 'Pocket Knife-Nile', 'Books')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Pocket Knife-Nile', 'Navigation')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Pocket Knife-Nile', 'Equipment')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Sextant', 'Clothes')
insert into tblSales(saleQty, itemName, deptName)
values (1, '', 'Equipment')
insert into tblSales(saleQty, itemName, deptName)
values (1, '', 'Recreation')
insert into tblSales(saleQty, itemName, deptName)
values (1, '', 'Furniture')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Pocket Knife-Nile', '')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Exploring in 10 easy lessons', 'Books')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'How to win foreign friends', '')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Compass', '')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Pith Helmet', '')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Elephant Polo stick', 'Recreation')
insert into tblSales(saleQty, itemName, deptName)
values (1, 'Camel Saddle', 'Recreation')
