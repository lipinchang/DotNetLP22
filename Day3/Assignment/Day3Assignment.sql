use pubs

--1) Select the author firtname and last name
select au_fname First_name, au_lname Last_name from authors

--2) Sort the titles by the title name in descending order and print all the details
select * from titles
order by title desc

--3) Print the number of titles published by every author
select count(title) 'No of titles published', a.au_id 'Author id'
from titles t join titleauthor ta on ta.title_id=t.title_id
join authors a on a.au_id=ta.au_id
group by a.au_id

--4) print the author name and title name
select CONCAT(au_fname, ' ', au_lname) 'Author name', title Title
from titles t join titleauthor ta on ta.title_id=t.title_id
join authors a on a.au_id=ta.au_id


--5) print the publisher name and the average advance for every publisher
select p.pub_name 'Publisher name', avg(advance) 'Average advance' from publishers p
join titles t on t.pub_id=p.pub_id
group by p.pub_name

--6) print the publishername, author name, title name and the sale amount(qty*price)
select pub_name 'Publisher name', CONCAT(au_fname, ' ', au_lname) 'Author name', title Title, s.qty*t.price 'Sale amount'
from titles t join titleauthor ta on ta.title_id=t.title_id
join authors a on a.au_id=ta.au_id
join sales s on s.title_id=t.title_id
join publishers p on p.pub_id=t.pub_id

--7) print the price of all that titles that have name that ends with s
select price, title from titles where title like ('%s')

--8) print the title names that contain 'and' in it
select title from titles where title like ('%and%')

--9) print the employee name and the publisher name
select concat(fname, ' ', lname) 'Employee name', pub_name 'Publisher name' from employee e
join publishers p on p.pub_id=e.pub_id

--10) print the publisher name and number of employees woking in it if the publisher has more than 2 employees
select pub_name 'Publisher name', count(emp_id) 'Number of employee working on it' from publishers p
join employee e on e.pub_id=p.pub_id
group by pub_name
having count(emp_id) > 2

--11) Print the author names who have published using teh publisher name 'Algodata Infosystems'
select CONCAT(au_fname, ' ', au_lname) 'Author name' from authors a
join titleauthor ta on ta.au_id=a.au_id
join titles t on t.title_id=ta.title_id
join publishers p on p.pub_id=t.pub_id
where pub_name='Algodata Infosystems'

--12) Print the employees of the publisher 'Algodata Infosystems'
select * from employee e
join publishers p on p.pub_id=e.pub_id
where pub_name='Algodata Infosystems'

--13)Create the following tables
--Employee(id-identity starts in 100 inc by 1, Name,age, phone cannot be null, gender)
--Salary(id-identity starts at 1 increments by 100,Basic,HRA,DA,deductions)
--EmployeeSalary(transaction_number int, employee_id-reference Employee's Id, Salary_id reference Salary Id, Date)
--PS - In the emeployee salary table transaction number is the primary key
--the combination of employee_id, salary_id and date should always be unique

create table tblEmployee
(id int identity(100,1) primary key,
name varchar(30),
age int ,
phone varchar(8) not null,
gender varchar(1)
)

create table tblSalary
(id int identity(1,100) primary key,
basic float,
HRA float,
DA float,
deductions float
)

create table tblEmployeeSalary
(transaction_number int primary key,
employee_id int references tblEmployee(id),
salary_id int references tblSalary(id),
salDate datetime
)

--Add a column email-varchar(100) to the employee table
alter table tblEmployee
add email varchar(100)

--Insert few records in all the tables
insert into tblEmployee(name, age, phone, gender) values ('LP',23, '87654321', 'F')
insert into tblEmployee(name, age, phone, gender) values ('timmy',23, '12345678', 'M')
insert into tblSalary(basic, HRA, DA, deductions) values (500,500,500,90)
insert into tblSalary(basic, HRA, DA, deductions) values (234,546777,24324,90)
insert into tblEmployeeSalary values (1, 100, 1,'1991-06-09 00:00:00.000')
insert into tblEmployeeSalary values (2, 101, 101,'1992-06-09 00:00:00.000')



--Create a procedure which will print the total salary of employee by taking the employee id and date
--total = Basic+HRA+DA-deductions
create proc proc_TotalSalary(@empId int, @date datetime)
as
begin
	declare @total float, @basic float, @hra float, @da float, @deduction float
	set @basic = (select basic from tblSalary s join tblEmployeeSalary es on es.salary_id=s.id where es.employee_id=@empId and salDate=@date)
	set @hra = (select hra from tblSalary s join tblEmployeeSalary es on es.salary_id=s.id where es.employee_id=@empId and salDate=@date)
	set @da = (select da from tblSalary s join tblEmployeeSalary es on es.salary_id=s.id where es.employee_id=@empId and salDate=@date)
	set @deduction = (select deductions from tblSalary s join tblEmployeeSalary es on es.salary_id=s.id where es.employee_id=@empId and salDate=@date)
	set @total = @basic + @hra + @da - @deduction

	print 'Total salary: '+ cast(@total as varchar(20))
end

exec proc_TotalSalary 100, '1991-06-09 00:00:00.000'

--q1LP Create a procudure which will calculate the average salary of an employee taking his ID
-- each salary just find avg	
create proc proc_AvgSalaryOfEmployee(@empId float)
as
begin
	declare @salary float
	set @salary = (select avg(Basic+HRA+DA-deductions) 'Avg salary' from tblSalary where id=@empID)

	print 'Average Salary: ' +cast(@salary as varchar(20))
end

exec proc_AvgSalaryOfEmployee 101

--Create a procedure which will catculate tax payable by employee
--Slabs as follows
--total - 100000 - 0%
--100000 > total < 200000 - 5%
--200000 > total < 350000 - 6%
--total > 350000 - 7.5%
create proc proc_CalculateTaxPayable(@empID int)
as
begin
	declare @total float, @tax float
	set @total = (select SUM(Basic+HRA+DA-deductions) from tblSalary where id=@empID)

	print 'Total Salary: '+ cast(@total as varchar(20))
	if(@total < 100000)
		set @tax = 0
	if(@total >= 100000 and @total < 200000)
		set @tax = 5
	if(@total >= 200000 and @total < 350000)
		set @tax = 6
	if(@total >= 350000)
		set @tax = 7.5

	print 'Tax payable: '+cast(@tax as varchar(20))+'%'
end

--14) Create a function that will take the basic,HRA and da returns the sum of the three
create proc proc_SumOfBasicHraDa(@basic float, @hra float, @da float)
as
begin
	declare @total float
	set @total = @basic+@hra+@da

	print 'Total: '+ cast(@total as varchar(20))
	
end

exec proc_SumOfBasicHraDa 5,5,5

--15) Create a cursor that will pick up every employee and print his details   --just simple query with cursor
--then print all the entries for his salary in the employeesalary table. 
--Also show the salary splitt up(Hint-> use the salary table)
DECLARE cur_employee CURSOR FOR select e.* , (basic+hra+ da-deductions) 'Total Salary', basic, hra, da, deductions
from tblEmployee e join tblEmployeeSalary es on es.employee_id=e.id 
join tblSalary s on s.id=es.salary_id

--correct
select e.* , (basic+hra+ da-deductions) 'Total Salary', basic, hra, da, deductions
from tblEmployee e join tblEmployeeSalary es on es.employee_id=e.id 
join tblSalary s on s.id=es.salary_id

select * from tblEmployee
select * from tblSalary
select * from tblEmployeeSalary


--16) https://www.hackerrank.com/challenges/maximum-element/problem
-- have got a not completely correct solution for this. needs more fixing and testing.

--17) https://www.geeksforgeeks.org/find-if-there-is-a-subarray-with-0-sum/
-- could not think of a way, so i looked at the solution and understood it