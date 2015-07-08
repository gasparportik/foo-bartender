CREATE PROCEDURE [dbo].[DeliverInvoice] 
	@InvoiceId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Delivered bit;
	DECLARE @SectionId int;
	SELECT @Delivered = Delivered, @SectionId = SectionId FROM Invoice WHERE Id = @InvoiceId;
	IF (@Delivered = 0) BEGIN
		DECLARE myCur CURSOR FOR SELECT ProductId, Quantity FROM InvoiceItem WHERE InvoiceId = @InvoiceId;
		DECLARE @Result int;
		DECLARE @ItemId int;
		DECLARE @Quantity float;
		BEGIN TRANSACTION;
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
		OPEN myCur;
		FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		WHILE (@@FETCH_STATUS <> -1)
		BEGIN
			EXEC @Result = [DeductStockForProduct]
					@ProductId = @ItemId,
					@SectionId = @SectionId,
					@Quantity = @Quantity;
			IF @Result > 0 BEGIN 
				CLOSE myCur;
				DEALLOCATE myCur;
				ROLLBACK;
				RAISERROR('The tiny net @ProductId',15,1);
				RETURN;
			END
			FETCH NEXT FROM myCur INTO @ItemId, @Quantity;
		END
		UPDATE Invoice SET Delivered = 1 WHERE Id = @InvoiceId;
		CLOSE myCur;
		DEALLOCATE myCur;
		COMMIT;
	END ELSE RAISERROR(100002,15,10);
END
