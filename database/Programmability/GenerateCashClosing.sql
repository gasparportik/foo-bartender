CREATE PROCEDURE [dbo].[GenerateCashClosing]
	@SaloonId int
AS
BEGIN
	SET NOCOUNT ON;
	IF (EXISTS(SELECT * FROM CashClosing WHERE DATEDIFF(dd,Date,GETDATE()) = 1 AND SaloonId = @SaloonId))
		RETURN -1;
	ELSE BEGIN
		DECLARE @Total int;
		SELECT @Total = SUM(SI.Price * SI.Quantity)
			FROM Sale S 
			INNER JOIN SaleItem SI ON SI.SaleId = S.Id
			INNER JOIN SaloonTable ST ON ST.Id = S.SaloonTableId
			WHERE DATEDIFF(day,S.Date,GETDATE()) = 1 AND ST.SaloonId = @SaloonId;
		IF @Total IS NOT NULL
		INSERT CashClosing VALUES(@SaloonId,GETDATE(), @Total);
	END
END