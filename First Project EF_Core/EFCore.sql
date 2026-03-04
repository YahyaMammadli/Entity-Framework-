GO
use master;

GO
CREATE DATABASE MyDB;

GO
use MyDB;


CREATE TABLE Supliers
(
[Id] INT PRIMARY KEY IDENTITY,
[CompanyName] NVARCHAR(100) NOT NULL,
[City] NVARCHAR(100) NOT NULL,
[Country] NVARCHAR(100) NOT NULL
)



CREATE TABLE Products 
(
[Id] INT PRIMARY KEY IDENTITY,
[ProductName] NVARCHAR(100) NOT NULL,
[SupplierId] INT NOT NULL FOREIGN KEY REFERENCES Supliers(Id),
[UnitPrice] DECIMAL(12,2) NULL DEFAULT 0,
[Package] NVARCHAR(30) NULL,
[IsDiscontinued] BIT NOT NULL DEFAULT 0
)

insert into Supliers (CompanyName, City, Country) values ('Step It Academy', 'Baku', 'Azerbaijan')
insert into Supliers (CompanyName, City, Country) values ('Meta', 'San Jose', 'USA')
insert into Supliers (CompanyName, City, Country) values ('Apple', 'Cupertino', 'USA')


SELECT * FROM Supliers;

SELECT * FROM Products;


SELECT * FROM Category;



UPDATE Products
SET UnitPrice = UnitPrice * 1.10
WHERE SupplierId = 1;


INSERT INTO Products (ProductName, SupplierId, UnitPrice, Package, IsDiscontinued) VALUES 
('Chai', 1, 18.00, '10 boxes x 20 bags', 0),
('Chang', 1, 19.00, '24 - 12 oz bottles', 0),
('Aniseed Syrup', 2, 10.00, '12 - 550 ml bottles', 0),
('Chef Anton''s Cajun Seasoning', 2, 22.00, '48 - 6 oz jars', 0),
('Grandma''s Boysenberry Spread', 3, 25.00, '12 - 8 oz jars', 0),
('Uncle Bob''s Organic Dried Pears', 3, 30.00, '12 - 1 lb pkgs.', 0),
('Northwoods Cranberry Sauce', 3, 40.00, '12 - 12 oz jars', 0),
('Queso Cabrales', 1, 21.00, '1 kg pkg.', 0),
('Tofu', 3, 23.25, '40 - 100 g pkgs.', 0),
('Ikura', 2, 31.00, '24 - 250 ml bottles', 0),
('Discontinued Item Example', 1, 10.00, 'some package', 1);








GO
use MyDB;

GO
CREATE TABLE Customers
(
[Id] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(100) NOT NULL
);

GO
CREATE TABLE Orders
(
[Id] INT PRIMARY KEY IDENTITY,
[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id),
[TotalAmount] INT,
[OrderNumber] INT
);



insert into Customers (Name) values ('Henrietta');
insert into Customers (Name) values ('Fran');
insert into Customers (Name) values ('Meaghan');
insert into Customers (Name) values ('Brantley');
insert into Customers (Name) values ('Katalin');
insert into Customers (Name) values ('Sam');


SELECT * FROM Customers;



insert into Orders (CustomerId, TotalAmount, OrderNumber) values (3, 858, 1234);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (2, 615, 0987);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (5, 731, 343);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (1, 283, 2324);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (2, 124, 343);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (1, 691, 2745);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (5, 258, 93834);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (2, 873, 3989);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (3, 673, 09393);
insert into Orders (CustomerId, TotalAmount, OrderNumber) values (4, 325, 9030);

SELECT * FROM Orders;

SELECT o.OrderNumber, c.[Name], o.TotalAmount
FROM Orders as o
JOIN Customers as c ON o.CustomerId = c.Id;



SELECT MAX(UnitPrice) FROM Products;


SELECT COUNT(*) FROM Products WHERE IsDiscontinued = 0;

SELECT * FROM Supliers


TRUNCATE TABLE Supliers;
DROP TABLE Products;

