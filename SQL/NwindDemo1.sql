use Northwind;

SELECT*FROM Employees;
SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE City ='London';

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE City <>'London';

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE HireDate>= '1-july-1993';

SELECT CategoryName,Description
FROM Categories;

SELECT ContactName ,CompanyName,ContactTitle,Phone
FROM Customers;

SELECT EmployeeID,Title,FirstName,LastName,Region 
FROM Employees;

SELECT RegionID,RegionDescription
FROM Region;

SELECT CompanyName,Fax,Phone,HomePage
FROM Suppliers;

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE (HireDate>='1-june-1992')
AND (HireDate<='15-december-1993')

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE (HireDate BETWEEN '1-june-1992' AND '15-december-1993')

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE (HireDate NOT BETWEEN'1-june-1992' AND '15-december-1993')

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE City='London' OR City='Seattle'

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE City IN('Seattle','Tacoma','Redmond')

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE City  NOT IN('Seattle','Tacoma','Redmond')

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE(FirstName NOT LIKE 'M%') AND (FirstName NOT LIKE 'A%')

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees
WHERE FirstName LIKE'[a-M]%' AND (City NOT LIKE'L%')

SELECT EmployeeID,FirstName,LastName,HireDate,City
FROM Employees 
WHERE FirstName LIKE'[^a-M]%'

----ORDER BY------

SELECT EmployeeID, FirstName, LastName, HireDate, City 
FROM Employees
ORDER BY City --ascending

 

SELECT EmployeeID, FirstName, LastName, HireDate,Country, City 
FROM Employees
ORDER BY Country, City DESC --descending: country in ascending, city in descending

 

SELECT EmployeeID, FirstName, LastName, HireDate,Country, City 
FROM Employees
ORDER BY Country, City

 

SELECT EmployeeID, FirstName, LastName, HireDate,Country, City 
FROM Employees
ORDER BY Country ASC, City ASC

 

SELECT EmployeeID, FirstName, LastName, HireDate,Country, City 
FROM Employees
ORDER BY Country DESC, City DESC


SELECT Title , FirstName,LastName 
FROM Employees 
ORDER BY 1,3;

SELECT Title , FirstName,LastName 
FROM Employees 
ORDER BY Title ,LastName;


-------------------------------------------EXERCISES-------------------------------------------
-----QUESTION 1----

SELECT CategoryName,Description
FROM Categories
ORDER BY CategoryName;

-----QUESTION2------

SELECT ContactName ,CompanyName,ContactTitle , Phone
FROM Customers
ORDER BY Phone;

----QUESTION3-------

SELECT EmployeeID, FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC

------QUESTION4------

SELECT OrderID ,OrderDate,ShippedDate,CUstomerID , freight
FROM Orders
ORDER BY freight DESC

----QUESTION5----

SELECT CompanyName,Fax,Phone,HomePage , Country
FROM Suppliers
ORDER BY Country DESC,CompanyName ASC;

-----QUESTION6----

SELECT Title,FirstName , LastName
FROM Employees
ORDER BY Title ASC,LastName DESC;

-------------------------------------------------------------------------------------------------

SELECT FirstName,LastName,Region
FROM Employees
WHERE Region IS NULL;

SELECT FirstName,LastName,Region
FROM Employees
WHERE Region IS NOT NULL;

---------------------------------------------EXERCISE2---------------------------------------------

-------QUESTION1-------

SELECT CompanyName , ContactName
FROM Customers
WHERE City='Buenos Aires';

------QUESTION2--------

SELECT ProductName ,UnitPrice,QuantityPerUnit
FROM Products
WHERE UnitsinStock=0;

------QUESTION3------

SELECT OrderDate,ShippedDate,CustomerID,Freight
FROM Orders
WHERE Orderdate='19-may-1997';

-----QUESTION4-----

SELECT FirstName,LastName,Country
FROM Employees
WHERE Country NOT IN ('USA');

----------------------------------ARITHMETIC OPERATION BETWEEN COLUMNS--------------------------------------------
SELECT FirstName+' '+LastName ------AS Name--->This gives the column a name.
FROM Employees

SELECT[OrderID],[Freight],[Freight]*0.1Tax
FROM Orders
WHERE Freight>=500;

SELECT[OrderID],[Freight],[Freight]*1.1 AS FreightTotal
FROM Orders
WHERE Freight>=500;

-----12/09/2023--------


USE Northwind
SELECT COUNT(*) AS NumEmployees 
FROM Employees;

SELECT SUM(Quantity) AS TotalUnits 
FROM [Order Details]
WHERE ProductID=3;

SELECT AVG(UnitPrice) AS AveragePrice 
FROM Products;

SELECT City,COUNT(EmployeeID) AS NumEmployees
FROM Employees
GROUP BY City;

SELECT City,COUNT(EmployeeID) AS NumEmployees
FROM Employees
GROUP BY City HAVING COUNT(EmployeeID)>1; -------------- We cant write it as NumEmployeeID here(i.e.) aliase cant be used here.

SELECT DISTINCT City
FROM Employees
ORDER BY City

SELECT COUNT(DISTINCT City)
AS NumCities 
FROM Employees

SELECT ProductID, SUM(Quantity) AS TotalUnits
FROM[Order Details]
GROUP BY ProductID HAVING SUM(Quantity)<200;

SELECT ProductID,AVG(UnitPrice) AS AveragePrice 
FROM Products 
GROUP BY ProductID HAVING AVG(UnitPrice)>70
ORDER BY AveragePrice;

SELECT CustomerID,COUNT(OrderID) AS NumOrders 
FROM Orders 
GROUP BY CustomerID HAVING COUNT(OrderID)>15
ORDER BY nUMoRDERS  DESC;

SELECT ProductID,UnitPrice 
FROM Products 
WHERE UnitPrice>70 
ORDER BY UnitPrice


----------------EXERCISES---------
----Q1) List freight as is amnd freight rounded to the first decimal?

USE Northwind
SELECT Freight,ROUND(Freight,1)
AS ApproxFreight
FROM Orders;

USE Northwind
SELECT Freight,ROUND(Freight,-1)
AS ApproxFreight
FROM Orders;

-------Q2)Select the unit price as is and unit price as a char(10) from the Product Table

USE Northwind

SELECT UnitPrice,CAST (UnitPrice AS CHAR(10)) 
FROM Products;
           
SELECT UnitPrice,'$'+CAST(UnitPrice AS CHAR(10))
FROM Products;
            ----------Once converted into char cant be used as arithmetic operations--------
SELECT UPPER(FirstName),UPPER(LastName)
FROM Employees;

SELECT SUBSTRING(Address,1,10)
FROM Customers;

-----------DATE Functions---------

USE Northwind	
SELECT LastName,BirthDate,HireDate,
DATEDIFF(Year,BirthDate,HireDate) AS HireAge 
FROM Employees 
ORDER BY HireAge;

SELECT FirstName,LastName,DATENAME(Month,BirthDate)
AS BirthMonth,DATEPART(month,BirthDate)
FROM Employees
ORDER BY DATEPART(month,BirthDate);

--------------------------------------------SUB QUERY------------------------------------------
USE Northwind
SELECT CompanyName 
FROM Customers
WHERE CustomerID=(SELECT CustomerID FROM Orders where OrderID=10290)

Use Northwind
SELECT CompanyName 
FROM Customers
WHERE CustomerID IN (SELECT CustomerID FROM Orders where OrderDate  BETWEEN '1-Jan-1997' AND '31-Dec-1997');

SELECT CompanyName 
FROM Customers
WHERE CustomerID IN (SELECT CustomerID FROM Orders where OrderDate BETWEEN '1997-01-01' AND '1997-12-31');


USE Northwind
SELECT*FROM Suppliers 
WHERE CompanyName='Grandma Kelly''sHomestead';
SELECT ProductName,SupplierID
FROM Products WHERE SupplierID IN(
	SELECT SupplierID FROM Suppliers WHERE CompanyName IN('Exotic Liquids','Grandma Kelly''s Homestead','Tokyo Traders'));

                                                ----------EXERCISE-----------
---------Q1)Create a query that shows all products by name that are in the seafood category

USE Northwind
SELECT ProductName
From Products
WHERE CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName='SeaFood')

-------Q2)Create a query that shows all comapnies  by name that sell productss in the categoryID 8

USE Northwind
SELECT CompanyName
FROM Suppliers
WHERE SupplierID IN(SELECT SupplierID FROM Products WHERE CategoryID=8)


------Q3)Create a quert that shows all companies by name that sell products in the seafood category.

USE Northwind
SELECT CompanyName
FROM Suppliers
WHERE SupplierID IN 
		(SELECT SupplierID FROM Products WHERE CategoryID=(
														SELECT CategoryID FROM Categories WHERE CategoryName='SeaFood'));

  