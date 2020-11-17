Drop Table Customer;
Drop Table Store;
Drop Table CustomerOrder;
Drop Table ProductOrdered;
DROP TABLE Inventory;
DROP TABLE PRICE;
DROP TABLE Product;

Create Table Product(
	ProductId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL
);

Create Table Price (
	ProductId INT NOT NULL,
	Price MONEY NOT NULL,
	StartTime SMALLDATETIME Default GETDATE(),
	Constraint Pk_Price PRIMARY KEY (ProductId, StartTime)
);

Alter Table Price 
	ADD FOREIGN KEY (ProductId) REFERENCES Product(ProductId);

Create Table Inventory(
	StoreId INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity INT Default 0,
	Constraint Pk_Inventory PRIMARY KEY (StoreId, ProductId)
)
Alter Table Inventory
	ADD FOREIGN KEY (ProductId) REFERENCES Product(ProductId);

Create Table ProductOrdered (
	TransactionNumber INT NOT NULL,
	ProductId INT NOT NULL,
	Quantity INT Default 0,
	Constraint Pk_Order PRIMARY KEY (TransactionNumber, ProductId)
);

Alter Table ProductOrdered
	ADD FOREIGN KEY (ProductId) REFERENCES Product(ProductId);

Create Table CustomerOrder(
	TransactionNumber INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	StoreId INT NOT NULL,
	CustomerId INT NOT NULL,
	TransactionTime SMALLDATETIME
);

Create Table Store(
	StoreId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL,
	Street NVARCHAR(50) NOT NULL,
	State NVARCHAR(30) NOT NULL,
	City NVARCHAR(30) NOT NULL,
	Zip NVARCHAR(9) NOT NULL
)

Create Table Customer(
	CustomerId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(28) NOT NULL,
	LastName NVARCHAR(28) NOT NULL,
	Email NVARCHAR(40) NULL,
	Phone NVARCHAR(12) NULL
)


Alter Table CustomerOrder
Add FOREIGN KEY (StoreId) REFERENCES Store(StoreId);

Alter Table CustomerOrder
ADD FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)

Alter Table ProductOrdered
	ADD FOREIGN KEY (TransactionNumber) REFERENCES CustomerOrder(TransactionNumber)
INSERT INTO PRODUCT (Name)
VALUES('Apple'), ('Orange'), ('Banana'), ('Watermelon'), ('Bread'), ('Ipod'), ('Iphone'), ('Galaxy S 10'), ('Pixel 3'), ('Pixel 4'), ('PS5'), ('XBOX ONE X'), ('GTX 3080'), ('TOOTH PASTE' );-- 

Delete From Price where StartTime='2020-11-13 20:52:00'

INSERT INTO PRICE (ProductId, Price)
VALUES(1,1.0), (2,1.50), (3,.38), (4, 2.5), (5,2.5), (6,150), (7,250), (8,500), (9,500), (10, 650), (11, 500), (12,500), (13,900), (14,2)

INSERT INTO Customer (FirstName, LastName, Email, Phone)
VALUES 
('Jordan', 'Garcia', 'jg@gmail.com', '8881231234'),
('Isidro', 'Buenro', 'Ib@yahoo.com', '877CASHNOW'),
('Gabby', 'McDude', 'gb@yahoo.com', '8892194545'),
('Nadia', 'Bread', 'Nb@crouton.net', '3458195347'),
('Luke', 'Flasher', 'lf@fish.com', '7604780934');

INSERT INTO Store (Name, Street, State, City, Zip) VALUES
('Walmart', '123 N Way Dr', 'IL', 'Palatine', '48329'),
('Target', '859 N 490 Dr', 'IN', 'Danville', '34859'),
('Subway', '349 Bread Rd', 'TX', 'Arlington', '83249');

INSERT INTO INVENTORY(StoreId, ProductId, Quantity) VALUES
(1,1,12),(1,2,19),(1,3,7), (1,4,92), (1,5,5), (1,6,3), (1,7,2), (2,4,12),(2,5,20), (2,6,10), (2,7,9), (2,8,3),(3,1,4), (3,11,1);

Alter table CustomerOrder
ADD CONSTRAINT CO_date
Default GETDATE() FOR TransactionTime 

INSERT INTO CustomerOrder (StoreId, CustomerId)
Values (1,1), (1,2), (1,3),(2,4), (2,1)

Insert into ProductOrdered Values
(1,1,1),(1,2,3),(1,3,1),(1,4,17);

Select