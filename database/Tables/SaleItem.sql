CREATE TABLE [dbo].[SaleItem](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[SaleId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Delivered] [bit] NOT NULL DEFAULT 0
)