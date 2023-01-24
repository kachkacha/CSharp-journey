--3
SELECT custid
	,empid
FROM sales.orders
WHERE year(orderdate) = 2016
	AND MONTH(orderdate) = 1

EXCEPT

SELECT custid
	,empid
FROM sales.orders
WHERE year(orderdate) = 2016
	AND MONTH(orderdate) = 2;

--4
SELECT custid
	,empid
FROM sales.orders
WHERE year(orderdate) = 2016
	AND MONTH(orderdate) = 1

INTERSECT

SELECT custid
	,empid
FROM sales.orders
WHERE year(orderdate) = 2016
	AND MONTH(orderdate) = 2;

--5
SELECT custid
	,empid
FROM sales.orders
WHERE year(orderdate) = 2016
	AND MONTH(orderdate) = 1

INTERSECT

SELECT custid
	,empid
FROM sales.orders
WHERE year(orderdate) = 2016
	AND MONTH(orderdate) = 2

EXCEPT

SELECT custid
	,empid
FROM sales.orders
WHERE year(orderdate) = 2015;

--6
SELECT country
	,region
	,city
FROM (
	SELECT 0 AS ord
		,country
		,region
		,city
	FROM HR.Employees
	
	UNION ALL
	
	SELECT 1
		,country
		,region
		,city
	FROM Production.Suppliers
	) AS locations
ORDER BY ord
	,country
	,region
	,city;