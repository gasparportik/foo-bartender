CREATE PROCEDURE [dbo].[DeductStockForProduct]
	@ProductId int,
	@SectionId int,
	@Quantity float
AS
BEGIN
	DECLARE dCur CURSOR FOR SELECT Id, Quantity FROM Stock 
		WHERE SectionId = @SectionId AND ProductId = @ProductId AND Quantity > 0;
	DECLARE @Remaining float;
	DECLARE @CurrentId int;
	DECLARE @CurrentQ float;
	
	SET @Remaining = @Quantity;	
	OPEN dCur;
	FETCH NEXT FROM dCur INTO @CurrentId, @CurrentQ;
	WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		IF @Remaining > @CurrentQ
		UPDATE Stock SET Quantity = 0 WHERE Id = @CurrentId;
		ELSE
		UPDATE Stock SET Quantity = Quantity - @Remaining WHERE Id = @CurrentId;
		SET @Remaining = @Remaining - @CurrentQ;
		FETCH NEXT FROM dCur INTO @CurrentId, @CurrentQ;
	END
	CLOSE dCur;
	DEALLOCATE dCur;
	IF (@Remaining > 0)
		RETURN (@Remaining * 1000);
	RETURN 0;
END