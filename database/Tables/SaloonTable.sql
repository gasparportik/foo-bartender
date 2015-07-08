CREATE TABLE [dbo].[SaloonTable](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[SaloonId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Shape] [int] NOT NULL
)