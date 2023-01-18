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



