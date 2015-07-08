CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[ReferenceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[SectionId] [int] NOT NULL,
	[Action] [varchar](50) NOT NULL,
	[Quantity] [float] NOT NULL,
	[OrigQuantity] [float] NOT NULL,
	[Price] [float] NOT NULL
)