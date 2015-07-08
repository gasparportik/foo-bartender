CREATE TABLE [dbo].[ReceptionItem](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[ReceptionId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Price] [float] NOT NULL
)