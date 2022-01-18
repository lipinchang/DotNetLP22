use Northwind

select * from Products

select ProductName from Products
select ProductName, QuantityPerUnit from Products
select ProductName Product_Name, QuantityPerUnit Quantity_In_Every_Unit from Products   --provide an alias name for display purposes

select * from Products where UnitPrice >= 15

select * from Products where UnitPrice >= 15 and UnitPrice <= 25
select * from Products where UnitPrice between 15 and 25	--alternative using between, same result
select * from Products where UnitPrice >= 15 and SupplierID = 17	--multiple cols

-- eg. select the products that are supplied by 15 or the unitsonstock is less than 5
select * from Products where SupplierID = 15 or UnitsInStock < 5

select * from Products where SupplierID in (8,12,13,18)		-- or use (not in)

select * from Products where ProductName = 'Ikura'
select * from Products where ProductName like 'Ikura'
select * from Products where ProductName like 'cha_' --'cha_'  underscore means 1 char
select * from Products where ProductName like 'cha%'

--aggregate func
select avg(UnitsInStock) Average_Stock from Products	--aggregate func cannot combine with another col. single value filter
select avg(UnitsInStock) Average_Stock, sum(UnitsInStock) 'Total number of units' from Products

-- eg. print the avg price of products that are supplied by supplier with id 2,6,9
select AVG(UnitPrice) Average_Price from Products where SupplierID in (2,6,9)

select COUNT(SupplierId) from Products
select COUNT(distinct SupplierId) from Products 
select distinct SupplierId from Products 

-- sorting
select * from Products order by SupplierID   --sort by. default is ascending
select * from Products order by SupplierID desc

select * from Products order by SupplierID,UnitsInStock
select * from Products order by SupplierID, UnitsInStock desc	 -- sort SupplierID by asc, UnitsInStock by desc

-- eg. print all the products sorted by supplierid where the product name should contain 'e'
select * from Products where ProductName like '%e%' order by SupplierID		--order by should be the last always

--group by
--when using aggregate func, any other col not aggregate func must be in group by then u can select
--find out each supplier have how many products
select SupplierId, COUNT(productid) 'Number of products' from Products    
group by SupplierId

select SupplierId, COUNT(productid) 'Number of products' from Products    
where UnitsInStock > 0
group by SupplierId
order by 2	--or use the alias name order by 'Number of products' OR order by 3 means 3rd col u selected

--using having. 
-- "The HAVING clause was added to SQL because the WHERE keyword cannot be used with aggregate functions"
select SupplierId, COUNT(productid) 'Number of products' from Products    
where UnitsInStock > 0
group by SupplierId
having COUNT(productid) > 2
order by 2

-- group, having, order by		correct order

-- eg. print the avg price of products sold by every salesperson if the avg is greater than 3 
-- where the ship country is france and the cust name contains 'e'
-- sort by results by the salesperson
select salesperson, avg(unitprice) avg_price from invoices where ShipCountry='france' and CustomerName like '%e%'
group by Salesperson
having avg(unitprice) > 3
order by Salesperson

select * from Suppliers 

select supplierid from Suppliers where country ='Japan'

select * from Products where SupplierID in --can use = if inner query only results to one results
(
	select supplierid from Suppliers where country ='Japan'
)

select * from Products where SupplierID = 
(
	select supplierid from Suppliers where CompanyName ='Tokyo Traders'
)

-- eg. select the avg units instock of products that are supplied by suppler whose region name is not null and the avg is greater than 3
--sort result by the avg units
select * from suppliers
select * from Invoices
select * from Products

select SupplierID, AVG(UnitsInStock) Average from Products where SupplierID in
(
	select SupplierID from Suppliers where Region is not null 
)
group by supplierid
having AVG(UnitsInStock) > 3
order by Average


-- eg. select the products details which are from catergory with name that has 'pro' in it
-- and the qty in stock is greater than 0 sort the result by the unit price
select *from Productswhere CategoryID in ( select CategoryID					  from Categories					  where CategoryName like '%pro%' )and UnitsInStock > 0order by UnitPrice


select * from [Order Details]
where ProductID in
(select ProductID from Products where CategoryID in 
(select CategoryID from Categories where CategoryName like '%pro%'))

-- joins: inner, outer cross
--join in default means inner join
select * from products where productid not in
(
	select distinct productid from [Order Details]
)

select productname, [Order Details].unitprice, quantity, [Order Details].unitprice*quantity 'Product Price'
from Products join [Order Details]
on Products.ProductID = [Order Details].ProductID

select ProductName, od.UnitPrice, Quantity, od.UnitPrice*Quantity 'Product Price'	-- <- this is alias name
from Products p inner join [Order Details] od		--using instance name. not alias name
on p.ProductID = od.ProductID		--equi join
order by ProductName, Quantity

-- cust name and order date for every order
select ContactName 'Customer Name', OrderDate 'Order Date'
from Customers c join Orders o
on c.CustomerID = o.CustomerID

--cust who has not made any order
select ContactName 'Customer Name'
from Customers
where CustomerID not in (select CustomerID from Orders)

select ContactName 'Customer Name', OrderDate 'Order Date'
from Customers c join Orders o
on c.CustomerID = o.CustomerID
order by 1

--want all cust even if not ordered , 
--related in both tables = inner join
--non related = outer join, full both side = full outer join, and right outer and left outer
select ContactName 'Customer Name', OrderDate 'Order Date'
from Customers c left outer join Orders o	--left
on c.CustomerID = o.CustomerID
order by 1

select ContactName 'Customer Name', OrderDate 'Order Date'
from Customers c full outer join Orders o	--full ; same
on c.CustomerID = o.CustomerID
order by 1

select ContactName 'Customer Name', OrderDate 'Order Date'
from Orders o right outer join Customers c
on o.CustomerID = c.CustomerID				--right; slight change but mostly same
order by 1



--nos of order each employee has made
select CONCAT(firstname, ' ', lastname) Employee_Name , count(OrderId) 'Number of orders'
from Employees e join Orders o 
on e.EmployeeID = o.EmployeeID
group by CONCAT(firstname, ' ', lastname)
having count(OrderId) > 50
order by 2

select * from [Order Details]

--print the orderid and product name, cust name

-- customer, order, order detail, products. 4 tables
select c.ContactName 'Customer Name', o.OrderId, p.ProductName, od.UnitPrice*od.Quantity 'Price'
from Customers c join Orders o on c.CustomerID = o.CustomerID
join [Order Details] od on od.OrderID = o.OrderID
join Products p on p.ProductID = od.ProductID
order by Price

--same res
select c.ContactName 'Customer Name', o.OrderId, p.ProductName, od.UnitPrice*od.Quantity 'Price'
from Customers c left outer join Orders o on c.CustomerID = o.CustomerID
left outer join [Order Details] od on od.OrderID = o.OrderID
left outer join Products p on p.ProductID = od.ProductID
order by Price

--same res
select c.ContactName 'Customer Name', o.OrderId, p.ProductName, od.UnitPrice*od.Quantity 'Price'
from Products p join [Order Details] od on p.ProductID = od.ProductID
join Orders o on od.OrderID = o.OrderID
right outer join Customers c on c.CustomerID = o.CustomerID
order by Price

--cross join like cartesian, least used join, probabilities. no related tables also can --add col, multipy no of rows
select * from Region cross join Shippers

select * from Employees

--self join. table
--employee reports to which manager
select emp.EmployeeID 'Employee ID', emp.FirstName 'Employee Name', mgr.EmployeeID 'Manager ID', mgr.FirstName 'Manager Name'
from Employees emp join Employees mgr on emp.ReportsTo = mgr.EmployeeID