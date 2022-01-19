use pubs

select * from titles
select * from authors

--1 select all the author's details
select * from authors

--2 print all the author's full name
select CONCAT(au_fname, ' ', au_lname) Author_full_name from authors

--3 print the avg price, total price of all the titles
select avg(price) avg_price, price from titles
group by price, title

--4 print the avg price of titles published by '0736'
select avg(price) avg_price from titles where pub_id = '0736'

--5 print the titles which have advance min 3200 and max of 5000
select title from titles where advance between 3200 and 5000

--6 print the titles which are the type 'psychology' or 'mod_cook'
select title from titles where type in ('psychology','mod_cook')

--7 print all titles published before '1991-06-09 00:00:00.000'
select title from titles where pubdate < '1991-06-09' 
--or select title from titles where pubdate < '1991-06-09 00:00:00.000'

--8 select all the authors from 'CA'
select * from authors where state ='CA'

--9 print the avg price of titles in every type
select avg(price) avg_price_of_title, type from titles
group by type

--10 print the sum of price of all the books published by every publisher
select sum(price) total_price_of_books_published, p.pub_name 
from titles t right outer join publishers p on t.pub_id = p.pub_id
group by p.pub_name

--11 print the first published title in every type
select type , min(pubdate) 'First published date' from titles  --no need title, titles table will do
group by type
--hint, group by type, min of published date
--correct ans

--12 calculate the total royalty for every publisher
select sum(royalty) total_royalty, pub_name from titles t join publishers p on t.pub_id=p.pub_id
group by pub_name

--13 print the titles sorted by published date
select title from titles 
order by pubdate

--14 print the titles sorted by publisher then by price
select title, pub_id, price from titles
order by pub_id, price

--15 print the books published by author 'CA'
select title, a.state from titles t 
join titleauthor ta on ta.title_id=t.title_id
join authors a on a.au_id=ta.au_id
where a.state ='CA'


--16 Print the author name of books whcih have royalty more than the average royalty of all the titletes
select CONCAT(a.au_fname, ' ', a.au_lname) Author_full_name, t.royalty from authors a
join titleauthor ta on a.au_id=ta.au_id
join titles t on t.title_id=ta.title_id
where t.royalty > (select avg(royalty) from titles)
-- alternative ans can be selection in selection in selection

--17 Print all the city and the number of pulishers in it, only if the city has more than one publisher
select city, count(pub_id) 'No of publisher' from publishers 
group by city 
having count(pub_id) > 1
--correct

--18) Print the total number of orders for every title
select count (title_id) total_num_of_orders, title_id from sales
group by title_id

--19) Print the total number of titles in every order
select count(title_id) total_num_of_titles, ord_num from sales 
group by ord_num


--20) Print the order date and the title name
select s.ord_date, t.title from sales s
join titles t on s.title_id=t.title_id

--21) Print all the title names and publisher names
select title, pub_name from titles t full outer join publishers p on t.pub_id=p.pub_id

--22) print all the publisher names(even if they have not published) and the title names that they have published
select pub_name, title from titles t full outer join publishers p on t.pub_id=p.pub_id

--23) print the title id and the numebr of authors contributing to it
select title_id, count(au_id) number_of_authors_contributing from titleauthor
group by title_id

--24) Print the titl name and the author name
select t.title, CONCAT(au_fname, ' ', au_lname) Author_full_name 
from titles t join titleauthor ta on t.title_id=ta.title_id
join authors a on a.au_id=ta.au_id

--25) print the title name, author name and the publisher name
select t.title, CONCAT(au_fname, ' ', au_lname) Author_full_name , p.pub_name
from titles t join titleauthor ta on t.title_id=ta.title_id
join authors a on a.au_id=ta.au_id
join publishers p on p.pub_id=t.pub_id

--26) print the titl name author name, publisher name, orderid, order date, quantity ordered and the total price
select t.title, CONCAT(au_fname, ' ', au_lname) Author_full_name , p.pub_name, ord_num, ord_date, qty, qty*t.price total_price
from titles t join titleauthor ta on t.title_id=ta.title_id
join authors a on a.au_id=ta.au_id
join publishers p on p.pub_id=t.pub_id
join sales s on s.title_id=t.title_id

--27) given a title name, print the stores in which it was sold
select stor_name 
from stores st join sales sa on sa.stor_id=st.stor_id
join titles t on t.title_id=sa.title_id
where title = 'The Gourmet Microwave'


--28) Select the stores who have taken more than 2 orders
--group by emp id n count > 2			
select stor_name, sa.stor_id, count(ord_num) no_of_orders from sales sa
join stores st on st.stor_id=sa.stor_id
group by stor_name,sa.stor_id 
having count(ord_num)>2

--alt
select stor_id , count(ord_num) no_of_orders from sales 
group by stor_id 
having count(ord_num)>2

--29) Select all the titles and print the first order date (titles that have not be ordered should also be present)
select  title, min(ord_date) first_order_date from titles t
left outer join sales s on s.title_id = t.title_id
group by title
--full outer join also can

--30) select all the data from teh orderes and the authors table --cross join
select * from sales cross join authors
