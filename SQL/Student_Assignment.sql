
USE testdb

CREATE TABLE SCHOOLDETAILS
(
SchoolId int IDENTITY(1,1) PRIMARY KEY,
SchoolName varchar(50) NOT NULL UNIQUE,
Description varchar(1000) NULL,
Address varchar(50) NULL,
Phone varchar(50) NULL,
PostCode varchar(50) NULL,
PostAddress varchar(50) NULL,
)

insert into SCHOOLDETAILS values ('DAV','CBSE','Chennai','1343211111','13','a1')
insert into SCHOOLDETAILS values ('Saraddha','cbse','Trichy','1483821212','11','e1')
insert into SCHOOLDETAILS values ('CSI','matric','Madurai','33343434','10','f1')
insert into SCHOOLDETAILS values ('Velemmal','matric','Nagerkoil','6767333867','14','g1')

select * from SCHOOLDETAILS

CREATE TABLE CLASS
(
ClassId int IDENTITY(1,1) PRIMARY KEY,
SchoolId int NOT NULL FOREIGN KEY REFERENCES SCHOOLDETAILS (SchoolId),
ClassName varchar(50) NOT NULL UNIQUE,
Description varchar(1000) NULL,
)

insert into CLASS values('1','eng','language')
insert into CLASS values('1','tam','language')
insert into CLASS values('1','maths','science')
insert into CLASS values('5','science','science')
insert into CLASS values('5','social','science')

select SCHOOLDETAILS.SchoolName, CLASS.ClassName from SCHOOLDETAILS INNER JOIN CLASS ON SCHOOLDETAILS.SchoolId = CLASS.SchoolId

declare @myvariable int
set @myvariable=4
print @myvariable

declare @mylastname varchar(50)
select @mylastname=LastName from CUSTOMER where CustomerId=2
print @mylastname

declare @find varchar(30)
set @find = 'X%'
select * from CUSTOMER
where LastName LIKE @find

declare @SchoolId int
-- Insert Data into SCHOOL table
insert into SCHOOLDETAILS(SchoolName) values ('DAV')
select @SchoolId = @@IDENTITY
-- Insert Courses for the specific School above in the COURSE table
insert into CLASS(ClassId,ClassName) values (@SchoolId, 'MIT-101')
insert into CLASS(ClassId,ClassName) values (@SchoolId, 'MIT-201')

select * from CLASS

CREATE TABLE COURSE
(
CourseId int IDENTITY(1,1) PRIMARY KEY,
ClassId int NOT NULL FOREIGN KEY REFERENCES SCHOOLDETAILS (SchoolId),
CourseName varchar(50) NOT NULL UNIQUE,
Description varchar(1000) NULL,
)

insert into COURSE values ('1','1','null')
insert into COURSE values ('1','2','null')
insert into COURSE values ('1','3','null')

declare @customerNumber int
select @customerNumber=CustomerNumber from CUSTOMER 
where CustomerId=2


if @customerNumber > 1002
print 'The Customer Number is larger than 1000'
else
print 'The Customer Number is not larger than 1000'

while (select AreaCode from CUSTOMER where CustomerId=1) < 20
begin
 update CUSTOMER set AreaCode = AreaCode + 1
end
select * from CUSTOMER


create table Grades(GradeId int ,StudentId int not null,CourseId int,Grade int)

insert into Grades values ('1','101','1','4')
insert into Grades values ('2','102','1','3')
insert into Grades values ('3','101','2','5')
insert into Grades values ('4','101','3','2')

select GradeId, StudentId, CourseId,
case Grade
when 5 then 'A'
when 4 then 'B'
when 3 then 'C'
when 2 then 'D'
when 1 then 'E'
when 0 then 'F'
else '-'
end as Grade from Grades

DECLARE
@CustomerId int, 
@phone varchar(50) 
DECLARE db_cursor CURSOR 
FOR SELECT CustomerId from CUSTOMER 
OPEN db_cursor 
FETCH NEXT FROM db_cursor INTO @CustomerId 
WHILE @@FETCH_STATUS = 0 
BEGIN 
 
select @phone=Phone from CUSTOMER where CustomerId=@CustomerId
 
 if LEN(@phone) < 9
 update CUSTOMER set Phone='Phone number is not valid' where 
CustomerId=@CustomerId
FETCH NEXT FROM db_cursor INTO @CustomerId 
END 
CLOSE db_cursor 
DEALLOCATE db_cursor

insert into CUSTOMER values('1018','Virat','Kohli','43','Europe','7683684874')
select * from CUSTOMER

DECLARE
@CustomeId int, 
@phon varchar(50) 
DECLARE db_cursor CURSOR 
FOR SELECT CustomerId from CUSTOMER 
OPEN db_cursor 
FETCH NEXT FROM db_cursor INTO @CustomeId 
WHILE @@FETCH_STATUS = 0 
BEGIN 
 
 select @phon=Phone from CUSTOMER where CustomerId=@CustomeId
 
 if LEN(@phon) < 8
 update CUSTOMER set Phone='Phone number is not valid' where 
CustomerId=@CustomeId
FETCH NEXT FROM db_cursor INTO @CustomeId 
END 
CLOSE db_cursor 
DEALLOCATE db_cursor

CREATE VIEW SchoolView AS SELECT SCHOOLDETAILS.SchoolName, CLASS.ClassName
FROM SCHOOLDETAILS  INNER JOIN CLASS ON SCHOOLDETAILS.SchoolId = CLASS.SchoolId

select * from SchoolView

CREATE PROCEDURE GetAllSchoolClasses AS
select SCHOOLDETAILS.SchoolName, CLASS.ClassName from SCHOOLDETAILS
inner join CLASS on SCHOOLDETAILS.SchoolId = CLASS.SchoolId order by SchoolName, ClassName

execute GetAllSchoolClasses

CREATE PROCEDURE GetSpecificSchoolClasses
@SchoolName varchar(50) AS select SCHOOLDETAILS.SchoolName, CLASS.ClassName
from SCHOOLDETAILS inner join CLASS on SCHOOLDETAILS.SchoolId = CLASS.SchoolId
where SchoolName=@SchoolName 

execute GetSpecificSchoolClasses 'DAV'

select * from CLASS

execute GetSpecificSchoolClasses 'DAV'


CREATE PROCEDURE GetSpecificSchoolClassess
@SchoolName varchar(50)
AS
select
SCHOOLDETAILS.SchoolName,
CLASS.ClassName
from
SCHOOLDETAILS
inner join CLASS on SCHOOLDETAILS.SchoolId = CLASS.SchoolId
where SchoolName=@SchoolName
order by ClassName

IF EXISTS (SELECT name 
 FROM sysobjects 
 WHERE name = 'sp_LIMS_IMPORT_REAGENT' 
 AND type = 'P')
DROP PROCEDURE sp_LIMS_IMPORT_REAGENT
GO
CREATE PROCEDURE sp_LIMS_IMPORT_REAGENT
@Name varchar(100),
@LotNumber varchar(100),
@ProductNumber varchar(100),
@Manufacturer varchar(100)
AS
SET NOCOUNT ON
if not exists (SELECT ReagentId FROM LIMS_REAGENTS WHERE [Name]=@Name)
INSERT INTO LIMS_REAGENTS ([Name], ProductNumber, Manufacturer)
 VALUES (@Name, @ProductNumber, @Manufacturer)
else
UPDATE LIMS_REAGENTS SET
[Name] = @Name,
ProductNumber = @ProductNumber,
Manufacturer = @Manufacturer,
WHERE [Name] = @Name
SET NOCOUNT OFF
GO

select AVG(Grade) as AvgGrade from Grades where StudentId=101

select * from Grades

select COUNT(*) as NumbersofCustomers from CUSTOMER

select FirstName, MAX(AreaCode) from CUSTOMER group by FirstName

select CourseId, AVG(Grade) from Grades group by CourseId
select CourseId, AVG(Grade) from Grades group by CourseId having AVG(Grade)>3

IF EXISTS (SELECT name 
 FROM sysobjects 
 WHERE name = 'CheckPhoneNumber' 
 AND type = 'TR')
DROP TRIGGER CheckPhoneNumber
GO
CREATE TRIGGER CheckPhoneNumber ON CUSTOMER
FOR UPDATE, INSERT
AS
DECLARE
@CustomerId int,
@Phone varchar(50),
@Message varchar(50)
set nocount on
select @CustomerId = CustomerId from INSERTED
select @Phone = Phone from INSERTED
set @Message = 'Phone Number ' + @Phone + ' is not valid'
if len(@Phone) < 8 --Check if Phone Number have less than 8 digits 
update CUSTOMER set Phone = @Message where CustomerId = @CustomerId
set nocount off
GO

INSERT INTO CUSTOMER (CustomerNumber, LastName, FirstName, AreaCode, Address, Phone) VALUES
('1013', 'Thomas', 'Musk', 51, 'SouthAfrica', '5455')

update CUSTOMER set Phone = '555555' where CustomerNumber = '1018'
