CREATE PROCEDURE [dbo].[LoadTablesForSaloon]
	@SaloonId int
AS
BEGIN
	SET NOCOUNT OFF;
	SELECT ST.Id, ST.Name, CASE WHEN S.Status IS NULL THEN 'FREE' ELSE S.Status END AS Status,
			A.Name AS Waiter, A.Id AS WaiterId, S.Id AS SaleId
		FROM SaloonTable ST 
		LEFT JOIN Sale S ON S.SaloonTableId = ST.Id AND S.Status <> 'DON'
		LEFT JOIN Account A ON A.Id = S.AccountId
		WHERE ST.SaloonId = @SaloonId;
END