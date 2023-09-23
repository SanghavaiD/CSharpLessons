Use Northwind
GO
BEGIN TRANSACTION
UPDATE dbo.Categories
SET CategoryName='FishFood_Sanghavai'
WHERE CategoryName='Sea Food'

---ROOLBACK TRANSACTION---

commit TRANSACTION
SELECT*FROM dbo.Categories
BEGIN TRANSACTION
UPDATE dbo.Categories
SET CategoryName='SeaFood'
WHERE CategoryName='FishFood'

---ROOLBACK TRANSACTION---

SELECT*FROM dbo.Categories
