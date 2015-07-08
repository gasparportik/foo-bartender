CREATE TABLE [dbo].[ProductionItem](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[ProductionId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Price] [float] NOT NULL
)