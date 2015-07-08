CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[CategoryId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[UnitId] [int] NOT NULL,
	[RecipeId] [int] NULL
)