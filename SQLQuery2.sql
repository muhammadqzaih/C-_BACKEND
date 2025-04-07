-- Create the database
CREATE DATABASE StoreDB;
GO

-- Use the created database
USE StoreDB;
GO

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Create Categories table
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    UnitPrice DECIMAL(10,2) NOT NULL,
    Discontinued BIT NOT NULL DEFAULT 0
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    OrderDate DATE NOT NULL DEFAULT GETDATE()
);

-- Create OrderDetails table
CREATE TABLE OrderDetails (
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    UnitPrice DECIMAL(10,2) NOT NULL,
    Quantity INT NOT NULL,
    Discount DECIMAL(5,2) NOT NULL DEFAULT 0,
    PRIMARY KEY (OrderID, ProductID)
);

-- Insert sample data into Categories
INSERT INTO Categories (CategoryName) VALUES
('Electronics'), ('Clothing'), ('Furniture'), ('Toys'), ('Food'), ('Books'), ('Beauty'), ('Sports');

-- Insert sample data into Customers
INSERT INTO Customers (Name) VALUES
('John Doe'), ('Jane Smith'), ('Alice Johnson'), ('Bob Brown'), ('Charlie Davis');

-- Insert sample data into Products
INSERT INTO Products (ProductName, CategoryID, UnitPrice, Discontinued) VALUES
('Laptop', 1, 1200.00, 0),
('T-Shirt', 2, 15.50, 0),
('Sofa', 3, 450.00, 0),
('Toy Car', 4, 25.00, 0),
('Chocolate', 5, 5.50, 0),
('Novel', 6, 20.00, 0),
('Shampoo', 7, 8.00, 0),
('Football', 8, 30.00, 0),
('Smartphone', 1, 800.00, 0),
('Jeans', 2, 40.00, 0),
('Dining Table', 3, 600.00, 0),
('Doll', 4, 18.00, 1),
('Cookies', 5, 3.50, 0),
('Magazine', 6, 10.00, 0),
('Face Cream', 7, 15.00, 0),
('Basketball', 8, 25.00, 0);

-- Insert sample data into Orders
INSERT INTO Orders (CustomerID, OrderDate) VALUES
(1, '2024-03-01'), (2, '2024-03-02'), (3, '2024-03-03'), (4, '2024-03-04'), (5, '2024-03-05');

-- Insert sample data into OrderDetails
INSERT INTO OrderDetails (OrderID, ProductID, UnitPrice, Quantity, Discount) VALUES
(1, 1, 1200.00, 1, 0),
(1, 2, 15.50, 2, 0),
(2, 3, 450.00, 1, 0),
(2, 4, 25.00, 3, 0.05),
(3, 5, 5.50, 5, 0.1),
(3, 6, 20.00, 2, 0),
(4, 7, 8.00, 4, 0),
(4, 8, 30.00, 1, 0),
(5, 9, 800.00, 1, 0.02),
(5, 10, 40.00, 2, 0);

---:



SELECT * FROM [dbo].[Customers];
SELECT * FROM [dbo].[Products];
SELECT * FROM [dbo].[Categories];
SELECT * FROM [dbo].[Orders];
SELECT * FROM [dbo].[OrderDetails];

--:

SELECT * FROM Orders WHERE OrderID = 3;

--: WE SHOULD USE FUNCTIONS TO AVOID DRY PROBLEM : DONT REAPEAT YOURSELF! : 

-- OrderID, ProductID, UnitPrice, Quantity, Discount, SubTotal:

SELECT OrderID,
       ProductID,
	   UnitPrice,
	   Quantity,
	   Discount,
	   dbo.CalculateSubTotal(OD.Quantity, OD.UnitPrice, OD.Discount) AS SubTotal
	   FROM OrderDetails OD
	   WHERE OrderID = 4;


-- OrderID , CustomerID, OrderDate, Total: 
SELECT  O.OrderID,
		O.CustomerID,
		O.OrderDate, 
		Convert(money, sum((1 - OD.Discount) * (OD.UnitPrice * OD.Quantity)),2) AS Total
From Orders O 
	 INNER JOIN
	 OrderDetails OD on O.OrderID = OD.OrderID where O.OrderID = 3
Group by O.OrderID,
		 O.CustomerID,
		 O.OrderDate;




-- FUNCTIONS
-- SCALLER FUNCTIONS(SINGLE VALUES): 
CREATE OR ALTER FUNCTION dbo.CalculateSubTotal(@quantity int, @unitPrice money, @dicount decimal)
RETURNS money WITH SCHEMABINDING -- for performance !! 
AS 
BEGIN
DECLARE @subTotal money
SELECT @subTotal = CONVERT(money, (1 - @dicount) * (@unitPrice * @quantity), 2);
RETURN @subTotal;
END
GO
 

-- 2 TABLE VALUES FUNCTION:

CREATE OR ALTER FUNCTION GetOrderDetails(@orderID INT)
RETURNS TABLE
AS 
RETURN
(
SELECT OrderID,
	ProductID,
	UnitPrice,
	Quantity,
	Discount,
	dbo.CalculateSubTotal(OD.Quantity, OD.UnitPrice, OD.Discount) AS SubTotal
	FROM OrderDetails OD
	WHERE OrderID = @orderID
);

SELECT * FROM DBO.GetOrderDetails(2)


-- Stored Procedure (Blue Section):

--   Return 0, single, or multiple:
-- → A stored procedure may not return any value, or it can return a single value or even multiple result sets.

--   Transaction Allowed:
-- → Stored procedures support transactions, meaning you can use BEGIN TRANSACTION, COMMIT, and ROLLBACK.

--   Input / Output Parameter:
-- → Stored procedures accept both input and output parameters, allowing them to modify and return values.

--   Procedure Can Call Function:
-- → A stored procedure can call a user-defined function inside its execution.

--   Can’t Be Used in SELECT / WHERE / HAVING:
-- → Stored procedures cannot be used inside SELECT, WHERE, or HAVING clauses because they do not return a direct value.

-------------------
-- User Defined Function (Green Section)
--   Must Return Single or Table
--→ A function must return either a single value (scalar function) or a table (table-valued function).

--  Transaction Not Allowed
--→ Functions do not support transactions, so you cannot use COMMIT or ROLLBACK.

--  Input Parameter Only
--→ Functions only accept input parameters and cannot modify data directly.

--  Function Can’t Call Procedure
--→ A function cannot call a stored procedure inside it.

--  Can Be Used in SELECT / WHERE / HAVING
--→ Functions can be used directly inside queries like SELECT, WHERE, and HAVING.