CREATE TABLE [dbo].[CustomersTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerID] INT NOT NULL, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(255) NOT NULL

)
