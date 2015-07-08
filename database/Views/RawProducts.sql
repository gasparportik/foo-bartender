CREATE VIEW [dbo].[RawProducts]
AS
SELECT     Id, CategoryId, Name, Price, UnitId, RecipeId
FROM         dbo.Product
WHERE     (RecipeId IS NULL)
