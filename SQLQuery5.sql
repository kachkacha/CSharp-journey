--1
-------------------------------------------------------------
with tmp
  as (select *,
             DATEFROMPARTS(YEAR(orderdate), 12, 31) as endofyear
        from sales.orders)
SELECT orderid,
       orderdate,
       custid,
       empid,
       orderdate
  FROM tmp
 WHERE orderdate <> endofyear;--2-1 ---------------------------------------------------------------SELECT o1.empid
	,max(o1.orderdate) AS maxorderdate
FROM sales.orders o1
GROUP BY o1.empid;--2-2----------------------------------------------------------------SELECT o1.empid
	,o1.orderdate
	,o1.orderid
	,o1.custid
FROM sales.orders o1
INNER JOIN (
	SELECT o1.empid
		,max(o1.orderdate) AS maxorderdate
	FROM sales.orders o1
	GROUP BY o1.empid
	) o2 ON o2.empid = o1.empid
	AND o2.maxorderdate = o1.orderdate;

--3-1
----------------------------------------------------------------
SELECT o1.orderid
	,o1.orderdate
	,o1.custid
	,o1.empid
	,ROW_NUMBER() OVER (
		ORDER BY o1.orderdate
			,o1.orderid
		) AS rownum
FROM sales.orders o1;
--3-2
-----------------------------------------------------------------
WITH tmp
AS (
	SELECT o1.orderid
		,o1.orderdate
		,o1.custid
		,o1.empid
		,ROW_NUMBER() OVER (
			ORDER BY o1.orderdate
				,o1.orderid
			) AS rownum
	FROM sales.orders o1
	)
SELECT *
FROM tmp
WHERE rownum BETWEEN 11
		AND 20;

 --4
 ------------------------------------------------------------------
WITH tmp
AS (
	SELECT empid
		,mgrid
	FROM hr.Employees
	WHERE empid = 9
	
	UNION ALL
	
	SELECT e.empid
		,e.mgrid
	FROM tmp t
	INNER JOIN hr.Employees e ON e.empid = t.mgrid
	)
SELECT *
FROM tmp;
--5-1
----------------------------------------------------------------------
CREATE VIEW Sales.VEmpOrders
AS
SELECT empid
	,year(orderdate) AS orderyear
	,sum(qty) AS qty
FROM sales.orders o
INNER JOIN sales.OrderDetails od ON od.orderid = o.orderid
GROUP BY empid
	,year(o.orderdate);

SELECT *
FROM Sales.VEmpOrders
ORDER BY empid
	,orderyear;--5-2-----------------------------------------------------------------------SELECT *
	,(
		SELECT sum(v2.qty)
		FROM Sales.VEmpOrders v2
		WHERE v2.empid = v1.empid
			AND v2.orderyear <= v1.orderyear
		) AS runtotal
FROM sales.VEmpOrders v1
ORDER BY v1.empid
	,v1.orderyear;
--6-1
-----------------------------------------------------------------------
CREATE FUNCTION Production.TopProducts (
	@supid AS INT
	,@n AS INT
	)
RETURNS TABLE
AS
RETURN

SELECT TOP (@n) productid
	,productname
	,unitprice
FROM Production.Products
WHERE supplierid = @supid
ORDER BY unitprice DESC;

SELECT *
FROM Production.TopProducts(5, 2);
--6-2
--------------------------------------------------------------------
SELECT s.supplierid
	,s.companyname
	,p.productid
	,p.productname
	,p.unitprice
FROM Production.Suppliers s
INNER JOIN Production.Products p ON p.supplierid = s.supplierid
WHERE p.productid IN (
		SELECT productid
		FROM Production.TopProducts(s.supplierid, 2)
		);

SELECT s.supplierid
	,s.companyname
	,p.productid
	,p.productname
	,p.unitprice
FROM Production.Suppliers s
CROSS APPLY (
	SELECT *
	FROM Production.TopProducts(s.supplierid, 2)
	) p;

