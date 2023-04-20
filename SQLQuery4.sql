1
----------------------------------------
select
  o.orderid,
  o.orderdate,
  o.custid,
  o.empid
from Sales.Orders o
where o.orderdate = (
    select MAX(orderdate)
    from Sales.Orders
  )

2
-------------------------------------------
select
  o.custid,
  o.orderid,
  o.orderdate,
  o.empid
from Sales.Orders o
where o.custid in (
    select custid
    from Sales.Orders
    group by custid
    having COUNT(*) = (
        select top(1) count(*) as qty
        from Sales.Orders
        group by custid
        order by qty desc
      )
  )

3
-----------------------------------------
select
  e.empid,
  e.firstname,
  e.lastname
from hr.Employees e
where e.empid not in (
    select distinct empid
    from Sales.Orders
    where orderdate >= '20160501'
  )

4
----------------------------------------------
select distinct c.country
from Sales.Customers c
where c.country not in (
    select distinct country
    from hr.Employees
  )
order by c.country


5
--------------------------------------------
select
  o.custid,
  o.orderid,
  o.orderdate,
  o.empid
from Sales.Orders o
where o.orderdadte = (
    select max(orderdate)
    from Sales.Orders o1
    where o1.custid = o.custid
  )

6
--------------------------------------------
select
  c.custid,
  c.company
from Sales.Customer c
where exists (
    select count(*)
    from Sales.Orders o
    where
      c.custid = o.custid
      and year(o.orderdate) = 2015
  )
  and not exist (
    select count(*)
    from Sales.Orders o
    where
      c.custid = o.custid
      and year(o.orderdate) = 2016
  )
  
  7
  ------------------------------------------
 select
  c.custid,
  c.company
from Sales.Customer c
where c.custid in (
    select o.custid
    from Sales.Orders o
    where
      o.custid is not null
      and exist (
        select od.orderid
        from Sales.OrderDetails od
        where od.orderid = o.orderid and od.productid = 12
      )
  )
  
  10
  --------------------------------------------
 select
  o.custid,
  o.orderdate,
  o.orderid,
  datediff(
    day,
    (
      select top(1) o1.orderdate
      from Sales.Orders o1
      where
        o.custid = o1.custid
        and o1.orderdate <= o.orderdate
      order by
        o1.orderdate desc, o1.orderid
    ),
    o.orderdate
  ) as diff
from Sales.Orders o
  


