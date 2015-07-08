CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[Name] [varchar](50) NOT NULL,
	[ProductId] [int] NULL,
	[Ratio] [float] NOT NULL
)