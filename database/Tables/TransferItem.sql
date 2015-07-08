CREATE TABLE [dbo].[TransferItem](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[TransferId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[Price] [float] NOT NULL
)