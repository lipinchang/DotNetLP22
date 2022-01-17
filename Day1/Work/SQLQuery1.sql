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

