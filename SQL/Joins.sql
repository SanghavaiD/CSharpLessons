                     ------------------------------------JOINS-------------------------------
--Q1)Create a report showing employee orders

USE Northwind
SELECT Employees.EmployeeID,Employees.FirstName,Employees.LastName,Orders.OrderID,Orders.OrderDate
FROM Employees JOIN Orders ON(Employees.EmployeeID=Orders.EmployeeID)
ORDER BY Orders.OrderDate;
 
 ---Alias---
 USE Northwind
SELECT e.EmployeeID , e.FirstName ,e.LastName,o.OrderID,o.OrderDate
FROM Employees e JOIN Orders o ON (e.EmployeeID=o.EmployeeID)
ORDER BY o.OrderDATE;

------Q) Create a report showing the orderID ,the name of the company that placed the order, 
--and the first and the last name of the associated employee.Only show orders placed after january 1,1998
---that shipped after they were required.Sort by company Name.

USE Northwind
SELECT o.OrderID,c.CompanyName , e.FirstName ,e.LastName
FROM Orders o
	JOIN Employees e ON(e.EmployeeID=o.EmployeeID)
	JOIN Customers c ON(c.CustomerID=o.CustomerID)
WHERE o.ShippedDate>o.RequiredDate AND o.OrderDate>'1-jan-1998' 
ORDER BY c.CompanyName;

---Q)Create a report that shows the number of employees and customer from each city that has employeesin it?


USE Northwind
SELECT COUNT(DISTINCT e.EmployeeID)AS numEmployees,
       COUNT(DISTINCT c.CustomerID) AS numCompanies,
		e.City,c.City
FROM Employees e JOIN Customers c ON
	(e.City=c.City)
GROUP BY e.City,c.City
ORDER BY numEmployees DESC ;


USE Northwind
SELECT COUNT(DISTINCT e.EmployeeID)AS numEmployees,
       COUNT(DISTINCT c.CustomerID) AS numCompanies,
		e.City,c.City
FROM Employees e LEFT JOIN Customers c ON
	(e.City=c.City)
GROUP BY e.City,c.City
ORDER BY numEmployees DESC ;

USE Northwind
SELECT COUNT(DISTINCT e.EmployeeID)AS numEmployees,
       COUNT(DISTINCT c.CustomerID) AS numCompanies,
		e.City,c.City
FROM Employees e RIGHT JOIN Customers c ON
	(e.City=c.City)
GROUP BY e.City,c.City
ORDER BY numEmployees DESC ;

---Create a report that shows the number of employees and customers from each city---

SELECT COUNT(DISTINCT e.EmployeeID)AS numEmployees,
       COUNT(DISTINCT c.CustomerID) AS numCompanies,
		e.City,c.City
FROM Employees e FULL JOIN Customers c ON
	(e.City=c.City)
GROUP BY e.City,c.City
ORDER BY numEmployees DESC ;

--Get the phone number of all shippers ,customers and suppliers

USE Northwind
SELECT CompanyName,Phone
FROM Shippers
	UNION
SELECT CompanyName,Phone
FROM Customers	
	UNION
SELECT CompanyName,Phone
FROM Suppliers 

ORDER BY CompanyName;

--Q1)Create a repOrt that shows the order IDs and the associated employee names for orders that shipped after the required date.
----There should be 37 rows returned.


SELECT o.OrderID,e.FirstName,e.LastName
FROM Employees e JOIN Orders o ON(e.EmployeeID=O.EmployeeID)
WHERE ShippedDate>RequiredDate
ORDER BY e.LastName, e.FirstName

---Q2)Create a report that shows the total quantity of products(from the[OrderDetails] table) ordered.
---Only show records for products for which the quantity ordered is fewer than 200.The report should return the following 5 rows.

SELECT p.ProductName , SUM(od.Quantity) AS TotalUnits
FROM [Order Details] od JOIN Products p ON(od.ProductID=p.ProductID)
GROUP BY p.ProductName
HAVING SUM(Quantity)<200;


---Q3)Create a report that shows the total number of orders by Customers since December 31, 1996.
---The report should return only rows for which the NumOrders is greater than 15.The report should return the following 5 rows.

SELECT c.CompanyName,Count(o.OrderID) AS NumOrders
FROM Customers c JOIN Orders o ON (c.CustomerID=o.CustomerID)
WHERE OrderDate>'31-Dec-1996'
Group BY c.CompanyName HAVING COUNT(O.OrderID)>15
ORDER BY NumOrders DESC;
    ----OR----
SELECT c.CompanyName,Count(o.OrderID) AS NumOrders
FROM Customers c JOIN Orders o ON (c.CustomerID=o.CustomerID)
WHERE OrderDate>'1996-12-31'
Group BY c.CompanyName HAVING COUNT(O.OrderID)>15
ORDER BY NumOrders DESC;

---Q4)Create  a report that shows the company name,order ID and total price of all the products of that has sold more than $10,000 worth.
---(There is no need of a group by clause in this report)

SELECT c.CompanyName , o.OrderID, od.UnitPrice*od.Quantity*(1-od.Discount) AS TotalPrice
from[Order Details] od
	JOIN Orders o ON(O.OrderID=od.OrderID)
	JOIN Customers c ON(c.CustomerID=o.CustomerID)
WHERE od.UnitPrice*od.Quantity*(1-od.Discount)>10000
ORDER BY TotalPrice Desc

---Q5)Create a report showing the contact name and phone numbers for all employees,customers,and suppliers.

SELECT ContactName ,Phone
FROM Customers	
	UNION
SELECT FirstName ,LastName
FROM Employees
	UNION
SELECT ContactName ,Phone
FROM Suppliers 
ORDER BY ContactName


SELECT EmployeeID,FirstName,ReportsTo,Title
FROM Employees



SELECT e1.EmployeeID,e1.FirstName,e2.FirstName AS ManagerName ,e1.Title     
----E1-->main table E2-->Clone of E1
FROM Employees e1 INNER JOIN Employees e2 ON e1.ReportsTo=e2.EmployeeID    


SELECT OrderID,Freight
FROM Orders;

SELECT*FROM Orders WHERE Freight in(SELECT Freight FROM Orders Order By Freight DESC);

SELECT*FROM Orders WHERE Freight in(SELECT TOP 3 Freight FROM Orders Order BY Freight DESC);

SELECT min(BirthDate)
FROM(SELECT TOP 3 BirthDate
		FROM Employees ORDER BY BirthDate DESC)a;

SELECT min(BirthDate)
FROM Employees
WHERE (SELECT TOP 3 BirthDate
		FROM Employees ORDER BY BirthDate DESC)

---Try it in testdb because u don't have a column called salary in northwind
---Q)How to find the second /third or the n th max salary from the Employee table

-----Inline Query/Derived Table
/*
SELECT*FROM Employees
WHERE SALARY=(SELECT max(sal) FROM Employee WHERE sal<
			 (SELECT max(sal) FROM Employee WHERE sal<
			 (SELECT max(sal) FROM Employee )));

-----SubQuery with derived table
SELECT*FROM Employees WHERE sal=
	(SELECT min(sal) FROM           ----SubQuery
		(SELECT TOP 3 sal FROM EmployeesORDER BY sal DESC)a;)
*/

SELECT OrderID,Freight 
FROM Orders
SELECT OrderID,Freight 
FROM Orders
ORDER BY Freight ASC
SELECT TOP 3 Freight 
FROM Orders 
ORDER BY Freight
SELECT min(Freight) 
FROM (SELECT TOP 7 Freight FROM Orders ORDER BY Freight DESC)a;
