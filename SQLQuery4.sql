1-1
-------------------------------------------
select e.empid, e.firstname, e.lastname, n
from HR.Employees e
cross join dbo.Nums
where n < 6;

1-2
-----------------------------------------------
select e.empid, DATEADD(day, n, CAST('20160611' as date)) as dt
from dbo.Nums
cross join HR.Employees e
where n < 6;

3
----------------------------------------------
select c.custid, count(distinct o.orderid) as numorders, sum(d.qty) as totalqty
from Sales.Customers c
inner join Sales.Orders o on c.custid = o.custid
inner join Sales.OrderDetails d on o.orderid = d.orderid
where c.country = N'USA'
group by c.custid
order by c.custid;

4
-----------------------------------------------
select c.custid, c.companyname, o.orderid, o.orderdate
from Sales.Customers c
left outer join Sales.Orders o on c.custid = o.custid;

5
-------------------------------------------------
select c.custid, c.companyname
from Sales.Customers c
left outer join Sales.Orders o on c.custid = o.custid
where o.custid is null;

6
---------------------------------------------------
select c.custid, c.companyname, o.orderid, o.orderdate
from Sales.Customers c
inner join Sales.Orders o on c.custid = o.custid
where o.orderdate = '20160212';

7
------------------------------------------------------
select c.custid, c.companyname, o.orderid, o.orderdate
from Sales.Customers c
left outer join (select * from Sales.Orders where orderdate = '20160212') o
on c.custid = o.custid;

9
------------------------------------------------------
select
	c.custid,
	c.companyname,
	iif(o.orderdate is null, 'No', 'Yes') as HasOrderOn20160212
from Sales.Customers c
left outer join (select * from Sales.Orders where orderdate = '20160212') o
on c.custid = o.custid
order by c.custid;

