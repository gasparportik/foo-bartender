CREATE VIEW [dbo].[RecipeProducts]
AS
SELECT     Id, CategoryId, Name, Price, UnitId
FROM         dbo.Product
WHERE     (RecipeId IS NULL)
