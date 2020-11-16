CREATE TABLE [dbo].[CustomersOrdersTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT REFERENCES CustomersTable(CustomerId) NOT NULL,
	[OrderId] INT REFERENCES OrdersTable(OrderId) NOT NULL
)
