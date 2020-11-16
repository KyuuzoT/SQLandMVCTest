CREATE TABLE [dbo].[CustomersOrdersTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT REFERENCES CustomersTable(Id) NOT NULL,
	[OrderId] INT REFERENCES OrdersTable(Id) NOT NULL
)
