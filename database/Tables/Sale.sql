CREATE TABLE [dbo].[Sale](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[SaloonTableId] [int] NOT NULL,
	[Status] [char](3) NOT NULL,
	[Date] [datetime] NOT NULL,
	[AccountId] [int] NOT NULL
)