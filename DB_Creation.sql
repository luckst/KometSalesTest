CREATE DATABASE KometSales
GO
USE KometSales
GO

-- Create the UserRoles table to define roles/profiles
CREATE TABLE UserRoles (
    Id uniqueidentifier PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);
GO

-- Create the Users table
CREATE TABLE Users (
    Id uniqueidentifier PRIMARY KEY,
    UserName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Active BIT NOT NULL DEFAULT(1),
    RoleId uniqueidentifier,
    CONSTRAINT FK_User_Role FOREIGN KEY (RoleId) REFERENCES UserRoles(Id)
);
GO

-- Create the Customers table
CREATE TABLE Customers (
    Id uniqueidentifier PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255),
    Phone NVARCHAR(20),
    Address NVARCHAR(255)
);
GO

-- Create the Products table
CREATE TABLE Products (
    Id uniqueidentifier PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL DEFAULT(0)
);
GO

-- Create the Sales table if it doesn't exist
CREATE TABLE Sales (
    Id uniqueidentifier PRIMARY KEY,
    SaleDate DATETIME NOT NULL,
    CustomerId uniqueidentifier,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Sale_Customer FOREIGN KEY (CustomerID) REFERENCES Customers(Id)
);
GO

-- Create the SalesDetail table
CREATE TABLE SalesDetail (
    Id uniqueidentifier PRIMARY KEY,
    SaleId uniqueidentifier,
    ProductId uniqueidentifier,
    Quantity INT NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_SaleDetail_Sale FOREIGN KEY (SaleId) REFERENCES Sales(Id),
    CONSTRAINT FK_SaleDetail_Product FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

GO
INSERT INTO UserRoles VALUES('debf9ed8-f44d-45aa-8345-e4e4290c1479', 'Administrator')
INSERT INTO UserRoles VALUES('8db22d55-da8c-41cd-8880-f8f9701a1376', 'Sales')
INSERT INTO UserRoles VALUES('a9de3bc1-1dde-4843-97de-df6a66a3cb4d', 'Reports')

GO
INSERT INTO Users VALUES(NEWID(), 'Administrator', 'systemadmin@email.com', 'SuperSecret123', 'debf9ed8-f44d-45aa-8345-e4e4290c1479')