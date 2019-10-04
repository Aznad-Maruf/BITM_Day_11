USE JustCustomers;
/*
CREATE DATABASE JustCustomers;


Create TABLE Customers(
	ID INT IDENTITY(1,1),
	Code VARCHAR(255) UNIQUE NOT NULL,
	Name VARCHAR(255) NOT NULL,
	Address VARCHAR(255),
	Contact VARCHAR(255) NOT NULL UNIQUE,

	CONSTRAINT PK_Customers PRIMARY KEY (ID)
);

CREATE TABLE Districts(
	ID INT IDENTITY(1,1),
	Name VARCHAR(255) UNIQUE NOT NULL,

	CONSTRAINT PK_Districts PRIMARY KEY (ID)
);

INSERT INTO Districts (Name) VALUES ('Dhaka');
INSERT INTO Districts (Name) VALUES ('Chadpur');
INSERT INTO Districts (Name) VALUES ('Borisal');
INSERT INTO Districts (Name) VALUES ('Vola');
INSERT INTO Districts (Name) VALUES ('Kurigram');
INSERT INTO Districts (Name) VALUES ('Chottogram');
INSERT INTO Districts (Name) VALUES ('Tangail');

INSERT INTO Customers (Code, Name, Address, Contact) VALUES ('0007', 'Maruf', '25/A, Kazipara', '01786164896');

CREATE VIEW CustomersWithDistrics AS
SELECT * FROM Customers LEFT JOIN Districts ON Districts.Name = '';

SELECT * FROM CustomersWithDistrics WHERE Code = '';
SELECT * FROM Customers

*/

UPDATE Customers SET Code = '', Name = '', Address = '', Contact = '' Where ID = '1';



