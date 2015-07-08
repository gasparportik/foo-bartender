CREATE TABLE [dbo].[CashClosing](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[SaloonId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total] [float] NOT NULL
)