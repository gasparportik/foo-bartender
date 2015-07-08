CREATE PROCEDURE [dbo].[LoadUnitsForProduct]
	@ProductId int
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT U.Id, U.Name, 1 AS Ratio FROM Product P INNER JOIN Unit U ON U.Id = P.UnitId WHERE P.Id = @ProductId 
	UNION
	SELECT U.Id, U.Name, U.Ratio FROM Unit U WHERE U.ProductId = @ProductId;
END
