--1
SELECT custid
	,orderid
	,qty
	,rank() OVER (
		PARTITION BY custid ORDER BY qty
		) AS rnk
	,DENSE_RANK() OVER (
		PARTITION BY custid ORDER BY qty
		) AS drnk
FROM dbo.Orders
--ORDER BY custid
--	,qty
;

--2
SELECT o.val
	,ROW_NUMBER() OVER (
		ORDER BY o.val
		) AS rownum
FROM (
	SELECT DISTINCT val
	FROM Sales.OrderValues
	) o;
--3
SELECT custid,
	orderid,
	qty,
	qty - lag(qty) OVER (
		PARTITION BY custid ORDER BY orderdate,
			orderid
		) AS diffprev,
	qty - lead(qty) OVER (
		PARTITION BY custid ORDER BY orderdate,
			orderid
		) AS diffnext
FROM dbo.Orders;

--4
SELECT empid,
	[2014],
	[2015],
	[2016]
FROM (
	SELECT empid,
		year(orderdate) AS orderyear,
		orderid
	FROM dbo.Orders
	) AS o
pivot(count(o.orderid) FOR o.orderyear IN (
			[2014],
			[2015],
			[2016]
			)) AS p;
