use Northwind
--stored procedure
--triggerscursors

--batch
begin
declare	--var
	@score int,
	@dob datetime,
	@name varchar(20)
	set @dob = '1982-10-19'
	set @score = 100	--set var val
	set @name = 'LP'
	set @score = @score - 20
	print 'Hello ' +@name
	print @score
	if(@score > 70)		--selection
		print 'Pass'
	else
		print 'Fail'
	print 'My birth date is '+ cast(@dob as varchar(20))		--cast to string to use it
end

--loop in SQL starts with a BEGIN block and ends with an END block.
begin
declare
	@count int
	set @count = 0
	while(@count < 10)    --iteration
	begin
		print @count
		set @count = @count +1
	end
end

--procedure - keep reusing/calling it
create procedure proc_FirstProcedure
as
begin
	print 'Hello frm procedure'
end

exec proc_FirstProcedure


create proc proc_PrintResult(@score int)	--with parameters
as
begin
	if(@score > 70)		
		print 'Pass'
	else
		print 'Fail'
end

exec proc_PrintResult 60  --add parameters val too



alter proc proc_PrintResult(@score int, @name varchar(20))	--with parameters
as
begin
print 'Hello ' +@name
	if(@score > 70)		
		print 'Pass'
	else
		print 'Fail'
end

exec proc_PrintResult 90, 'Tim'		--calling statement

--either use proc/procedure
create proc proc_calculate(@amount float, @tax float out)
as
begin
	print 'Calculating.......'
	set @tax = @amount*10.2/100
	print 'Done'
end

declare @giventax float		--need declare var to print out val later
exec proc_calculate 10000, @giventax out	--out means return value from SP
print @giventax


select * from [Order Details]

create proc proc_PrintPayable(@OrderNumber varchar(5))
as
begin
	declare
	@CustName varchar(20),
	@Gross float,
	@Discount float,
	@Freight float,
	@NetPrice float
	set @CustName = (select ContactName from Customers where CustomerID 
					= (select CustomerID from Orders where OrderID = @OrderNumber))
	print 'Hello ' + @CustName
	set @Gross = (select sum(unitprice*quantity) from [Order Details] where OrderID = @OrderNumber)
	set @Discount = (select sum(discount) from [Order Details] where OrderID = @OrderNumber)
	if(@Discount >0)
		set @Gross = @Gross - (@Gross*@Discount/100)
	set @Freight = (select Freight from Orders where OrderID = @OrderNumber)
	set @NetPrice = @Gross+@Freight
	print 'Gross amount ' + cast(@Gross as varchar(20))
	print 'Freight amount ' + cast(@Freight as varchar(20))
	print '-------------------'
	print 'Net price '+ cast(@NetPrice as varchar(20))
end

exec proc_PrintPayable '10249'
--benefit of SP, improves performance greatly, execution plan is only generated once unlike normal way(adhoc query) 
--which is everytime
--1 compiles and gens a execution plan once
--2 avoiding data injection. sp can pass value to parameter directly
--3 added level of encapsulation
--4 programmer doesnt need to know the SP, but only know how to use it

--simple queries using SP
create proc proc_FetchAllCustomers
as
	select * from Customers

exec proc_FetchAllCustomers


create table tblSimple
(f1 int primary key,
f2 varchar(20))

create proc proc_InsertIntoSimple(@f1 int, @f2 varchar(20))
as
	insert into tblSimple values(@f1,@f2)

exec proc_InsertIntoSimple 101, 'Hello'

select * from tblSimple

--transactions. executing either all or none of the query. 
-- eg. buying something online but something like bank card error suddenly appears, transaction has to roll back entirely

create table tblStatus
(f1 int,
msg varchar(20)
)

begin tran		--can use tran/transaction
	insert into tblSimple values (102, 'Check')
	insert into tblStatus values (102, 'Success')
	if((select count(f1) from tblSimple where f2 = 'Check')>0)
		rollback
	else
		commit

select * from tblSimple
select * from tblStatus

alter proc proc_Transaction(@f1 int, @f2 varchar(20))
as
begin
	begin tran		--can use tran/transaction
	declare @count int
	set @count = (select count(f1) from tblSimple where f2 = @f2)
	insert into tblSimple values (@f1, @f2)
	insert into tblStatus values (@f1, 'Success')
	if(@count>0)
		rollback	--rollback all the dml queries
	else
		commit		--after commit u cannot rollback at all
end

exec proc_Transaction 104, 'NewHello'

--exercise
--create a stored procedure that will calculate the total salary
--take input of basic, dearness allowance (da), house rent allowance(HRA), deductions and the number of leaves
--if the number of leav is more than 2, deduct the pay for the extra days and calculate the nett salary
--cal one day 

alter proc proc_CalculateTotalSalary(@Basic float, @DearnessAllowance float, @HouseRentAllowance float, @Deductions float, @NoOfLeaves int)
as
begin
	declare @TotalSalary float
	set @TotalSalary = @Basic + @DearnessAllowance + @HouseRentAllowance + @Deductions
	if(@NoOfLeaves > 2)
		set @TotalSalary =  @TotalSalary - (((@NoOfLeaves-2)/@NoOfLeaves)*@TotalSalary)
		
	print 'Total salary ' + cast(@TotalSalary as varchar(20))
	
end

exec proc_CalculateTotalSalary 3000, 50, 500, 0,3
--my logic is abit wrong

--ans
create proc proc_calTotalSalary(@basic float, @da float, @hra float, @deduction float, @numLeaves int)
as
begin
	Declare
		@nettSalary float,
		@grossSalary float
	set @grossSalary = @basic + @da + @hra - @deduction
	if(@numLeaves > 2)
	begin
	declare 
		@perDaySal float
		set @perDaySal = @grossSalary / 30
		set @nettSalary = @grossSalary - ((@numLeaves -2)*@perDaySal)
		print 'Leave Deductions '+  cast(((@numLeaves -2)*@perDaySal) as varchar(20))
	end
	else
	   set @nettSalary = @grossSalary
	print 'Gross Salary '+cast(@grossSalary as varchar(20))
	print '---------------------------------------'
	print 'Net Salary '+cast(@nettSalary as varchar(20))
end


--func will have to return a value
--scalar return single value

create function fn_Sample(@num int)
returns int
as
begin
	return @num*@num
end

select dbo.fn_Sample(10)
select  dbo.fn_Sample(UnitPrice) from Products

--functions cannot have print statements
create function fn_calTotalSalary(@basic float, @da float, @hra float, @deduction float, @numLeaves int)
returns float
as
begin
	Declare
		@nettSalary float,
		@grossSalary float
	set @grossSalary = @basic + @da + @hra - @deduction
	if(@numLeaves > 2)
	begin
	declare 
		@perDaySal float
		set @perDaySal = @grossSalary / 30
		set @nettSalary = @grossSalary - ((@numLeaves -2)*@perDaySal)
		
	end
	else
	   set @nettSalary = @grossSalary
	return @nettSalary
end

select dbo.fn_calTotalSalary(3000, 50, 500, 0,3)


--func that returns table
create function fn_calSalTable(@basic float, @da float, @hra float, @deduction float, @numLeaves int)
returns @SalTable Table(
GrossAmount float,
LeaveDeductions float,
NetAmount float
)
as
begin
	Declare
		@nettSalary float,
		@grossSalary float
	set @grossSalary = @basic + @da + @hra - @deduction
	if(@numLeaves > 2)
	begin
	declare 
		@perDaySal float
		set @perDaySal = @grossSalary / 30
		set @nettSalary = @grossSalary - ((@numLeaves -2)*@perDaySal)
		insert into @SalTable values(@grossSalary, ((@numLeaves -2)*@perDaySal), @nettSalary)
	end
	else
	begin			--BEGIN and END are just like { and } 
	   set @nettSalary = @grossSalary
	   insert into @SalTable values (@grossSalary, 0, @nettSalary)
	end
	return
end

select * from dbo.fn_calSalTable(10000, 5000, 3000, 1500,4)
--func is not great for queries for exsiting func
--only if u return back table then u can write dml queries for functions

--trigger
create trigger trg_InsertCheck
on tblSimple
for Insert
as 
begin
	print 'Hello'
end

--when insert then print hello automatically
insert into tblSimple values (105, 'dgsdgs')

-- triggers used mainly in ddl, dml queries

create trigger trg_UpdateCheck
on tblSimple
for Update
as 
begin
	print 'Hello'
end

--when insert then print hello automatically
update tblSimple set f2 ='ddd' where f1=105

select * from tblSimple


create table account
(accno int primary key,
balance float
)

create table trans
(tranno int primary key,
fromacc int references account(accno),
toacc int references account(accno),
amount float,
status varchar(100)
)

insert into account values (101, 5000)
insert into account values (102, 1000)
insert into account values (103, 10000)

select * from account

create trigger trg_Transact
on trans
for insert
as
begin
	declare @bal float, @check float, @credit float
	set @bal = (select balance from account where accno = (select fromacc from inserted))  --inserted is a implicit role
	set @credit = (select amount from inserted)
	set @check = @bal - (select amount from inserted)
	if(@check < 500)
		update trans set status = 'Failed' where tranno = (select tranno from inserted)
	else
	begin
		update account set balance = @check where accno = (select fromacc from inserted)
		update account set balance = balance + @credit where accno = (select toacc from inserted)
		update trans set status = 'Success' where tranno = (select tranno from inserted)

	end
end

select * from account
select * from trans

insert into trans values(3,101,102,3100,null)


--cursors, implicit and explicit(go row by row n do work), can use with dml. its just a pointer
declare 
@account int,
@balance float

DECLARE cur_account CURSOR FOR select * from account	--cursor's declaration

OPEN cur_account

FETCH NEXT FROM cur_account INTO @account, @balance

while(@@FETCH_STATUS = 0)  --fetch stats is -1 if no record
begin		
	print 'Account number: '+cast(@account as varchar(20))
	print 'Account balance: '+cast(@balance as varchar(20))
	print '-------------------------------'

	
		DECLARE @amount float, @status varchar(20)
		DECLARE cur_tran CURSOR FOR select amount, status from trans where fromacc = @account

		OPEN cur_tran

		FETCH NEXT FROM cur_tran INTO @amount, @status

		while(@@FETCH_STATUS = 0)
		begin
			print '					Account number: ' + cast(@amount as varchar(20))
			print '					Account balance: ' + @status
			print '-------------------------------'
			FETCH NEXT FROM cur_tran INTO @amount, @status
		end

		CLOSE cur_tran
		DEALLOCATE cur_tran

	FETCH NEXT FROM cur_account INTO @account,@balance
end

CLOSE cur_account
DEALLOCATE cur_account
--nested cursor for above eg.