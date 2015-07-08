CREATE TABLE [dbo].[InvoiceItem](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[InvoiceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Value] [float] NOT NULL,
	[VAT] [float] NOT NULL
)