CREATE TABLE [dbo].[RecipeItem](
	[Id] [int] IDENTITY NOT NULL PRIMARY KEY,
	[RecipeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL
)